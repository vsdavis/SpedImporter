using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using SpedImporter.Application.Interfaces;
using SpedImporter.Desktop.Models;
using SpedImporter.Infrastructure.Data;

namespace SpedImporter.Desktop;

public partial class MainForm : Form
{
    private readonly ISpedImportService? _importService;
    private readonly AppDbContext? _dbContext;
    private bool _isBusy;

    public MainForm()
    {
        InitializeComponent();
        ConfigureGrid();
        ResetSummary();
    }

    public MainForm(ISpedImportService importService, AppDbContext dbContext) : this()
    {
        _importService = importService;
        _dbContext = dbContext;
    }

    private bool EmModoDesigner => LicenseManager.UsageMode == LicenseUsageMode.Designtime;

    private void ConfigureGrid()
    {
        dgvRecentImports.AutoGenerateColumns = false;
        dgvRecentImports.Columns.Clear();

        dgvRecentImports.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ImportacaoGridItem.Arquivo),
            HeaderText = "Arquivo",
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            MinimumWidth = 220
        });

        dgvRecentImports.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ImportacaoGridItem.Status),
            HeaderText = "Status",
            Width = 130
        });

        dgvRecentImports.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ImportacaoGridItem.Linhas),
            HeaderText = "Linhas",
            Width = 90,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvRecentImports.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ImportacaoGridItem.Leiaute),
            HeaderText = "Leiaute",
            Width = 90
        });

        dgvRecentImports.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ImportacaoGridItem.Avisos),
            HeaderText = "Avisos",
            Width = 80,
            DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
        });

        dgvRecentImports.Columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = nameof(ImportacaoGridItem.DataImportacaoUtc),
            HeaderText = "Importado em",
            Width = 170,
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Format = "dd/MM/yyyy HH:mm",
                NullValue = "-"
            }
        });
    }

    private async void MainForm_Load(object sender, EventArgs e)
    {
        if (EmModoDesigner || _dbContext is null)
            return;

        try
        {
            await RefreshRecentImportsAsync();
            SetStatus("Sistema pronto para importar arquivos SPED.");
            AppendLog("Aplicação iniciada com sucesso.");
        }
        catch (Exception ex)
        {
            SetStatus("Falha ao carregar o painel inicial.");
            AppendLog($"Erro ao carregar dados iniciais: {ex.Message}");
        }
    }

    private void btnBrowse_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Title = "Selecione o arquivo SPED",
            Filter = "Arquivos texto (*.txt)|*.txt|Arquivos SPED (*.sped)|*.sped|Todos os arquivos (*.*)|*.*",
            CheckFileExists = true,
            Multiselect = false
        };

        if (dialog.ShowDialog(this) == DialogResult.OK)
        {
            txtFilePath.Text = dialog.FileName;
            AppendLog($"Arquivo selecionado: {dialog.FileName}");
            SetStatus("Arquivo pronto para importação.");
        }
    }

    private async void btnImport_Click(object sender, EventArgs e)
    {
        if (_isBusy)
            return;

        if (_importService is null || _dbContext is null)
        {
            MessageBox.Show(
                "Os serviços de importação ainda não foram inicializados.",
                "SPED Importer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        var filePath = txtFilePath.Text.Trim();

        if (string.IsNullOrWhiteSpace(filePath))
        {
            MessageBox.Show(
                "Selecione um arquivo antes de iniciar a importação.",
                "SPED Importer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            return;
        }

        if (!File.Exists(filePath))
        {
            MessageBox.Show(
                "O arquivo informado não foi encontrado.",
                "SPED Importer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            return;
        }

        try
        {
            ToggleBusy(true);
            SetStatus("Importação em andamento...");
            AppendLog($"Iniciando importação do arquivo '{Path.GetFileName(filePath)}'.");

            var importacaoId = await _importService.ImportAsync(filePath);
            var resumo = await BuildSummaryAsync(importacaoId);

            ApplySummary(resumo);
            await RefreshRecentImportsAsync();

            AppendLog($"Importação concluída com sucesso. Id: {resumo.Id}");
            SetStatus("Importação concluída.");

            MessageBox.Show(
                $"Importação concluída com sucesso.\n\nId: {resumo.Id}\nLinhas: {resumo.Linhas}\nAvisos: {resumo.Avisos}",
                "SPED Importer",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            SetStatus("Importação falhou.");
            AppendLog($"Erro na importação: {ex.Message}");

            MessageBox.Show(
                ex.Message,
                "Erro ao importar arquivo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
        finally
        {
            ToggleBusy(false);
        }
    }

    private async void dgvRecentImports_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0 || _dbContext is null)
            return;

        if (dgvRecentImports.Rows[e.RowIndex].DataBoundItem is not ImportacaoGridItem item)
            return;

        try
        {
            var resumo = await BuildSummaryAsync(item.Id);
            ApplySummary(resumo);
            SetStatus("Resumo carregado a partir do histórico.");
            AppendLog($"Resumo da importação {item.Id} exibido na tela.");
        }
        catch (Exception ex)
        {
            AppendLog($"Erro ao carregar resumo da importação {item.Id}: {ex.Message}");
        }
    }

    private async Task RefreshRecentImportsAsync()
    {
        if (_dbContext is null)
            return;

        var data = await _dbContext.Importacoes
            .AsNoTracking()
            .OrderByDescending(x => x.DataImportacaoUtc)
            .Take(10)
            .Select(x => new
            {
                x.Id,
                x.NomeArquivo,
                x.DataImportacaoUtc,
                x.Status,
                x.TotalLinhas,
                x.VersaoLeiaute,
                Avisos = _dbContext.RegistrosBrutos.Count(r => r.ImportacaoId == x.Id && !r.Processado)
            })
            .ToListAsync();

        var items = data
            .Select(x => new ImportacaoGridItem
            {
                Id = x.Id,
                Arquivo = x.NomeArquivo,
                DataImportacaoUtc = x.DataImportacaoUtc.ToLocalTime(),
                Status = x.Status,
                Linhas = x.TotalLinhas,
                Leiaute = x.VersaoLeiaute ?? "-",
                Avisos = x.Avisos
            })
            .ToList();

        dgvRecentImports.DataSource = items;
        lblHistoryCount.Text = $"{items.Count} importação(ões) exibida(s)";
    }

    private async Task<ImportacaoSummary> BuildSummaryAsync(Guid importacaoId)
    {
        if (_dbContext is null)
            throw new InvalidOperationException("Banco de dados não inicializado.");

        var importacao = await _dbContext.Importacoes
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == importacaoId)
            ?? throw new InvalidOperationException("Importação não encontrada.");

        var avisos = await _dbContext.RegistrosBrutos
            .AsNoTracking()
            .CountAsync(x => x.ImportacaoId == importacaoId && !x.Processado);

        var periodo = string.IsNullOrWhiteSpace(importacao.PeriodoInicial) || string.IsNullOrWhiteSpace(importacao.PeriodoFinal)
            ? "-"
            : $"{FormatDate(importacao.PeriodoInicial)} a {FormatDate(importacao.PeriodoFinal)}";

        return new ImportacaoSummary
        {
            Id = importacao.Id,
            Arquivo = importacao.NomeArquivo,
            Status = importacao.Status,
            Linhas = importacao.TotalLinhas,
            Leiaute = importacao.VersaoLeiaute ?? "-",
            Periodo = periodo,
            Avisos = avisos
        };
    }

    private void ApplySummary(ImportacaoSummary summary)
    {
        lblLastIdValue.Text = summary.Id.ToString();
        lblLastFileValue.Text = summary.Arquivo;
        lblLastStatusValue.Text = summary.Status;
        lblLastLinesValue.Text = summary.Linhas.ToString("N0");
        lblLastLayoutValue.Text = summary.Leiaute;
        lblLastPeriodValue.Text = summary.Periodo;
        lblLastWarningsValue.Text = summary.Avisos.ToString("N0");
    }

    private void ResetSummary()
    {
        lblLastIdValue.Text = "-";
        lblLastFileValue.Text = "Nenhuma importação executada";
        lblLastStatusValue.Text = "-";
        lblLastLinesValue.Text = "0";
        lblLastLayoutValue.Text = "020";
        lblLastPeriodValue.Text = "-";
        lblLastWarningsValue.Text = "0";
        lblHistoryCount.Text = "0 importação(ões) exibida(s)";
        txtLog.Text = string.Empty;
    }

    private void ToggleBusy(bool busy)
    {
        _isBusy = busy;
        btnImport.Enabled = !busy;
        btnBrowse.Enabled = !busy;
        txtFilePath.Enabled = !busy;
        UseWaitCursor = busy;
        Cursor = busy ? Cursors.WaitCursor : Cursors.Default;
    }

    private void SetStatus(string message)
    {
        lblStatusValue.Text = message;
    }

    private void AppendLog(string message)
    {
        txtLog.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
    }

    private static string FormatDate(string? value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length != 8)
            return value ?? "-";

        return $"{value[0..2]}/{value[2..4]}/{value[4..8]}";
    }

    private void cardAction_Enter(object sender, EventArgs e)
    {

    }

    private void layoutRoot_Paint(object sender, PaintEventArgs e)
    {

    }

    private void lblSubtitle_Click(object sender, EventArgs e)
    {

    }
}
