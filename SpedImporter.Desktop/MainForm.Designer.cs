namespace SpedImporter.Desktop;

partial class MainForm
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        cardLog = new GroupBox();
        txtLog = new TextBox();
        cardHistory = new GroupBox();
        lblHistoryCount = new Label();
        dgvRecentImports = new DataGridView();
        cardSummary = new GroupBox();
        summaryLayout = new TableLayoutPanel();
        lblLastWarningsValue = new Label();
        lblLastWarningsTitle = new Label();
        lblLastPeriodValue = new Label();
        lblLastPeriodTitle = new Label();
        lblLastLayoutValue = new Label();
        lblLastLayoutTitle = new Label();
        lblLastLinesValue = new Label();
        lblLastLinesTitle = new Label();
        lblLastStatusValue = new Label();
        lblLastStatusTitle = new Label();
        lblLastFileValue = new Label();
        lblLastFileTitle = new Label();
        lblLastIdValue = new Label();
        lblLastIdTitle = new Label();
        cardAction = new GroupBox();
        lblStatusValue = new Label();
        lblStatusTitle = new Label();
        btnImport = new Button();
        cardFile = new GroupBox();
        lblHelp = new Label();
        btnBrowse = new Button();
        txtFilePath = new TextBox();
        lblFilePath = new Label();
        panelHeader = new Panel();
        lblHeaderBadge = new Label();
        lblSubtitle = new Label();
        lblTitle = new Label();
        layoutRoot = new TableLayoutPanel();
        cardLog.SuspendLayout();
        cardHistory.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvRecentImports).BeginInit();
        cardSummary.SuspendLayout();
        summaryLayout.SuspendLayout();
        cardAction.SuspendLayout();
        cardFile.SuspendLayout();
        panelHeader.SuspendLayout();
        layoutRoot.SuspendLayout();
        SuspendLayout();
        // 
        // cardLog
        // 
        cardLog.BackColor = Color.White;
        layoutRoot.SetColumnSpan(cardLog, 12);
        cardLog.Controls.Add(txtLog);
        cardLog.Dock = DockStyle.Fill;
        cardLog.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        cardLog.ForeColor = Color.FromArgb(15, 23, 42);
        cardLog.Location = new Point(16, 699);
        cardLog.Margin = new Padding(16, 8, 16, 16);
        cardLog.Name = "cardLog";
        cardLog.Padding = new Padding(16, 12, 16, 16);
        cardLog.Size = new Size(1152, 146);
        cardLog.TabIndex = 5;
        cardLog.TabStop = false;
        cardLog.Text = "Log da sessão";
        // 
        // txtLog
        // 
        txtLog.BackColor = Color.FromArgb(248, 250, 252);
        txtLog.BorderStyle = BorderStyle.FixedSingle;
        txtLog.Dock = DockStyle.Fill;
        txtLog.Font = new Font("Consolas", 10F);
        txtLog.Location = new Point(16, 30);
        txtLog.Multiline = true;
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = ScrollBars.Vertical;
        txtLog.Size = new Size(1120, 100);
        txtLog.TabIndex = 0;
        // 
        // cardHistory
        // 
        cardHistory.BackColor = Color.White;
        layoutRoot.SetColumnSpan(cardHistory, 12);
        cardHistory.Controls.Add(lblHistoryCount);
        cardHistory.Controls.Add(dgvRecentImports);
        cardHistory.Dock = DockStyle.Fill;
        cardHistory.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        cardHistory.ForeColor = Color.FromArgb(15, 23, 42);
        cardHistory.Location = new Point(16, 440);
        cardHistory.Margin = new Padding(16, 8, 16, 8);
        cardHistory.Name = "cardHistory";
        cardHistory.Padding = new Padding(16, 12, 16, 16);
        cardHistory.Size = new Size(1152, 243);
        cardHistory.TabIndex = 4;
        cardHistory.TabStop = false;
        cardHistory.Text = "Histórico recente";
        // 
        // lblHistoryCount
        // 
        lblHistoryCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHistoryCount.Font = new Font("Segoe UI", 9F);
        lblHistoryCount.ForeColor = Color.FromArgb(71, 85, 105);
        lblHistoryCount.Location = new Point(877, 28);
        lblHistoryCount.Name = "lblHistoryCount";
        lblHistoryCount.Size = new Size(255, 15);
        lblHistoryCount.TabIndex = 1;
        lblHistoryCount.Text = "0 importação(ões) exibida(s)";
        lblHistoryCount.TextAlign = ContentAlignment.MiddleRight;
        // 
        // dgvRecentImports
        // 
        dgvRecentImports.AllowUserToAddRows = false;
        dgvRecentImports.AllowUserToDeleteRows = false;
        dgvRecentImports.AllowUserToResizeRows = false;
        dgvRecentImports.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dgvRecentImports.BackgroundColor = Color.White;
        dgvRecentImports.BorderStyle = BorderStyle.None;
        dgvRecentImports.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        dgvRecentImports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvRecentImports.Dock = DockStyle.Bottom;
        dgvRecentImports.Location = new Point(16, 51);
        dgvRecentImports.MultiSelect = false;
        dgvRecentImports.Name = "dgvRecentImports";
        dgvRecentImports.ReadOnly = true;
        dgvRecentImports.RowHeadersVisible = false;
        dgvRecentImports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvRecentImports.Size = new Size(1120, 176);
        dgvRecentImports.TabIndex = 0;
        dgvRecentImports.CellDoubleClick += dgvRecentImports_CellDoubleClick;
        // 
        // cardSummary
        // 
        cardSummary.BackColor = Color.White;
        layoutRoot.SetColumnSpan(cardSummary, 12);
        cardSummary.Controls.Add(summaryLayout);
        cardSummary.Dock = DockStyle.Fill;
        cardSummary.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        cardSummary.ForeColor = Color.FromArgb(15, 23, 42);
        cardSummary.Location = new Point(16, 270);
        cardSummary.Margin = new Padding(16, 8, 16, 8);
        cardSummary.Name = "cardSummary";
        cardSummary.Padding = new Padding(16, 12, 16, 16);
        cardSummary.Size = new Size(1152, 154);
        cardSummary.TabIndex = 3;
        cardSummary.TabStop = false;
        cardSummary.Text = "Resumo da última importação";
        // 
        // summaryLayout
        // 
        summaryLayout.ColumnCount = 4;
        summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        summaryLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        summaryLayout.Controls.Add(lblLastWarningsValue, 3, 3);
        summaryLayout.Controls.Add(lblLastWarningsTitle, 3, 2);
        summaryLayout.Controls.Add(lblLastPeriodValue, 2, 3);
        summaryLayout.Controls.Add(lblLastPeriodTitle, 2, 2);
        summaryLayout.Controls.Add(lblLastLayoutValue, 1, 3);
        summaryLayout.Controls.Add(lblLastLayoutTitle, 1, 2);
        summaryLayout.Controls.Add(lblLastLinesValue, 0, 3);
        summaryLayout.Controls.Add(lblLastLinesTitle, 0, 2);
        summaryLayout.Controls.Add(lblLastStatusValue, 3, 1);
        summaryLayout.Controls.Add(lblLastStatusTitle, 3, 0);
        summaryLayout.Controls.Add(lblLastFileValue, 1, 1);
        summaryLayout.Controls.Add(lblLastFileTitle, 1, 0);
        summaryLayout.Controls.Add(lblLastIdValue, 0, 1);
        summaryLayout.Controls.Add(lblLastIdTitle, 0, 0);
        summaryLayout.Dock = DockStyle.Fill;
        summaryLayout.Location = new Point(16, 30);
        summaryLayout.Name = "summaryLayout";
        summaryLayout.RowCount = 4;
        summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
        summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 22F));
        summaryLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        summaryLayout.Size = new Size(1120, 108);
        summaryLayout.TabIndex = 0;
        // 
        // lblLastWarningsValue
        // 
        lblLastWarningsValue.AutoEllipsis = true;
        lblLastWarningsValue.Dock = DockStyle.Fill;
        lblLastWarningsValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastWarningsValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblLastWarningsValue.Location = new Point(843, 78);
        lblLastWarningsValue.Name = "lblLastWarningsValue";
        lblLastWarningsValue.Size = new Size(274, 34);
        lblLastWarningsValue.TabIndex = 15;
        lblLastWarningsValue.Text = "0";
        // 
        // lblLastWarningsTitle
        // 
        lblLastWarningsTitle.AutoSize = true;
        lblLastWarningsTitle.Font = new Font("Segoe UI", 9F);
        lblLastWarningsTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblLastWarningsTitle.Location = new Point(843, 56);
        lblLastWarningsTitle.Name = "lblLastWarningsTitle";
        lblLastWarningsTitle.Size = new Size(41, 15);
        lblLastWarningsTitle.TabIndex = 14;
        lblLastWarningsTitle.Text = "Avisos";
        // 
        // lblLastPeriodValue
        // 
        lblLastPeriodValue.AutoEllipsis = true;
        lblLastPeriodValue.Dock = DockStyle.Fill;
        lblLastPeriodValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastPeriodValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblLastPeriodValue.Location = new Point(563, 78);
        lblLastPeriodValue.Name = "lblLastPeriodValue";
        lblLastPeriodValue.Size = new Size(274, 34);
        lblLastPeriodValue.TabIndex = 13;
        lblLastPeriodValue.Text = "-";
        // 
        // lblLastPeriodTitle
        // 
        lblLastPeriodTitle.AutoSize = true;
        lblLastPeriodTitle.Font = new Font("Segoe UI", 9F);
        lblLastPeriodTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblLastPeriodTitle.Location = new Point(563, 56);
        lblLastPeriodTitle.Name = "lblLastPeriodTitle";
        lblLastPeriodTitle.Size = new Size(95, 15);
        lblLastPeriodTitle.TabIndex = 12;
        lblLastPeriodTitle.Text = "Período apurado";
        // 
        // lblLastLayoutValue
        // 
        lblLastLayoutValue.AutoEllipsis = true;
        lblLastLayoutValue.Dock = DockStyle.Fill;
        lblLastLayoutValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastLayoutValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblLastLayoutValue.Location = new Point(283, 78);
        lblLastLayoutValue.Name = "lblLastLayoutValue";
        lblLastLayoutValue.Size = new Size(274, 34);
        lblLastLayoutValue.TabIndex = 11;
        lblLastLayoutValue.Text = "020";
        // 
        // lblLastLayoutTitle
        // 
        lblLastLayoutTitle.AutoSize = true;
        lblLastLayoutTitle.Font = new Font("Segoe UI", 9F);
        lblLastLayoutTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblLastLayoutTitle.Location = new Point(283, 56);
        lblLastLayoutTitle.Name = "lblLastLayoutTitle";
        lblLastLayoutTitle.Size = new Size(96, 15);
        lblLastLayoutTitle.TabIndex = 10;
        lblLastLayoutTitle.Text = "Versão do leiaute";
        // 
        // lblLastLinesValue
        // 
        lblLastLinesValue.AutoEllipsis = true;
        lblLastLinesValue.Dock = DockStyle.Fill;
        lblLastLinesValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastLinesValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblLastLinesValue.Location = new Point(3, 78);
        lblLastLinesValue.Name = "lblLastLinesValue";
        lblLastLinesValue.Size = new Size(274, 34);
        lblLastLinesValue.TabIndex = 9;
        lblLastLinesValue.Text = "0";
        // 
        // lblLastLinesTitle
        // 
        lblLastLinesTitle.AutoSize = true;
        lblLastLinesTitle.Font = new Font("Segoe UI", 9F);
        lblLastLinesTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblLastLinesTitle.Location = new Point(3, 56);
        lblLastLinesTitle.Name = "lblLastLinesTitle";
        lblLastLinesTitle.Size = new Size(110, 15);
        lblLastLinesTitle.TabIndex = 8;
        lblLastLinesTitle.Text = "Total de linhas lidas";
        // 
        // lblLastStatusValue
        // 
        lblLastStatusValue.AutoEllipsis = true;
        lblLastStatusValue.Dock = DockStyle.Fill;
        lblLastStatusValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastStatusValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblLastStatusValue.Location = new Point(843, 22);
        lblLastStatusValue.Name = "lblLastStatusValue";
        lblLastStatusValue.Size = new Size(274, 34);
        lblLastStatusValue.TabIndex = 7;
        lblLastStatusValue.Text = "-";
        // 
        // lblLastStatusTitle
        // 
        lblLastStatusTitle.AutoSize = true;
        lblLastStatusTitle.Font = new Font("Segoe UI", 9F);
        lblLastStatusTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblLastStatusTitle.Location = new Point(843, 0);
        lblLastStatusTitle.Name = "lblLastStatusTitle";
        lblLastStatusTitle.Size = new Size(39, 15);
        lblLastStatusTitle.TabIndex = 6;
        lblLastStatusTitle.Text = "Status";
        // 
        // lblLastFileValue
        // 
        lblLastFileValue.AutoEllipsis = true;
        lblLastFileValue.Dock = DockStyle.Fill;
        lblLastFileValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastFileValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblLastFileValue.Location = new Point(283, 22);
        lblLastFileValue.Name = "lblLastFileValue";
        lblLastFileValue.Size = new Size(274, 34);
        lblLastFileValue.TabIndex = 5;
        lblLastFileValue.Text = "Nenhuma importação executada";
        // 
        // lblLastFileTitle
        // 
        lblLastFileTitle.AutoSize = true;
        lblLastFileTitle.Font = new Font("Segoe UI", 9F);
        lblLastFileTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblLastFileTitle.Location = new Point(283, 0);
        lblLastFileTitle.Name = "lblLastFileTitle";
        lblLastFileTitle.Size = new Size(49, 15);
        lblLastFileTitle.TabIndex = 4;
        lblLastFileTitle.Text = "Arquivo";
        // 
        // lblLastIdValue
        // 
        lblLastIdValue.AutoEllipsis = true;
        lblLastIdValue.Dock = DockStyle.Fill;
        lblLastIdValue.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblLastIdValue.ForeColor = Color.FromArgb(15, 23, 42);
        lblLastIdValue.Location = new Point(3, 22);
        lblLastIdValue.Name = "lblLastIdValue";
        lblLastIdValue.Size = new Size(274, 34);
        lblLastIdValue.TabIndex = 3;
        lblLastIdValue.Text = "-";
        // 
        // lblLastIdTitle
        // 
        lblLastIdTitle.AutoSize = true;
        lblLastIdTitle.Font = new Font("Segoe UI", 9F);
        lblLastIdTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblLastIdTitle.Location = new Point(3, 0);
        lblLastIdTitle.Name = "lblLastIdTitle";
        lblLastIdTitle.Size = new Size(75, 15);
        lblLastIdTitle.TabIndex = 2;
        lblLastIdTitle.Text = "Id da import.";
        // 
        // cardAction
        // 
        cardAction.BackColor = Color.White;
        layoutRoot.SetColumnSpan(cardAction, 4);
        cardAction.Controls.Add(lblStatusValue);
        cardAction.Controls.Add(lblStatusTitle);
        cardAction.Controls.Add(btnImport);
        cardAction.Dock = DockStyle.Fill;
        cardAction.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        cardAction.ForeColor = Color.FromArgb(15, 23, 42);
        cardAction.Location = new Point(695, 119);
        cardAction.Margin = new Padding(8, 16, 16, 8);
        cardAction.Name = "cardAction";
        cardAction.Padding = new Padding(16, 12, 16, 16);
        cardAction.Size = new Size(473, 135);
        cardAction.TabIndex = 2;
        cardAction.TabStop = false;
        cardAction.Text = "Execução";
        cardAction.Enter += cardAction_Enter;
        // 
        // lblStatusValue
        // 
        lblStatusValue.Font = new Font("Segoe UI", 9.5F);
        lblStatusValue.ForeColor = Color.FromArgb(30, 41, 59);
        lblStatusValue.Location = new Point(20, 84);
        lblStatusValue.Name = "lblStatusValue";
        lblStatusValue.Size = new Size(334, 41);
        lblStatusValue.TabIndex = 2;
        lblStatusValue.Text = "Pronto para nova importação.";
        // 
        // lblStatusTitle
        // 
        lblStatusTitle.AutoSize = true;
        lblStatusTitle.Font = new Font("Segoe UI", 9F);
        lblStatusTitle.ForeColor = Color.FromArgb(71, 85, 105);
        lblStatusTitle.Location = new Point(20, 61);
        lblStatusTitle.Name = "lblStatusTitle";
        lblStatusTitle.Size = new Size(104, 15);
        lblStatusTitle.TabIndex = 1;
        lblStatusTitle.Text = "Status da interface";
        // 
        // btnImport
        // 
        btnImport.BackColor = Color.FromArgb(37, 99, 235);
        btnImport.FlatAppearance.BorderSize = 0;
        btnImport.FlatStyle = FlatStyle.Flat;
        btnImport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnImport.ForeColor = Color.White;
        btnImport.Location = new Point(20, 27);
        btnImport.Name = "btnImport";
        btnImport.Size = new Size(160, 34);
        btnImport.TabIndex = 0;
        btnImport.Text = "Iniciar importação";
        btnImport.UseVisualStyleBackColor = false;
        btnImport.Click += btnImport_Click;
        // 
        // cardFile
        // 
        cardFile.BackColor = Color.White;
        layoutRoot.SetColumnSpan(cardFile, 8);
        cardFile.Controls.Add(lblHelp);
        cardFile.Controls.Add(btnBrowse);
        cardFile.Controls.Add(txtFilePath);
        cardFile.Controls.Add(lblFilePath);
        cardFile.Dock = DockStyle.Fill;
        cardFile.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
        cardFile.ForeColor = Color.FromArgb(15, 23, 42);
        cardFile.Location = new Point(16, 119);
        cardFile.Margin = new Padding(16, 16, 8, 8);
        cardFile.Name = "cardFile";
        cardFile.Padding = new Padding(16, 12, 16, 16);
        cardFile.Size = new Size(663, 135);
        cardFile.TabIndex = 1;
        cardFile.TabStop = false;
        cardFile.Text = "Arquivo para importação";
        // 
        // lblHelp
        // 
        lblHelp.AutoSize = true;
        lblHelp.Font = new Font("Segoe UI", 9F);
        lblHelp.ForeColor = Color.FromArgb(71, 85, 105);
        lblHelp.Location = new Point(20, 104);
        lblHelp.Name = "lblHelp";
        lblHelp.Size = new Size(451, 15);
        lblHelp.TabIndex = 3;
        lblHelp.Text = "Dica: a rotina atual persiste o arquivo bruto, valida o registro 0000 e exige leiaute 020.";
        // 
        // btnBrowse
        // 
        btnBrowse.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnBrowse.BackColor = Color.FromArgb(226, 232, 240);
        btnBrowse.FlatAppearance.BorderSize = 0;
        btnBrowse.FlatStyle = FlatStyle.Flat;
        btnBrowse.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnBrowse.Location = new Point(517, 55);
        btnBrowse.Name = "btnBrowse";
        btnBrowse.Size = new Size(120, 34);
        btnBrowse.TabIndex = 2;
        btnBrowse.Text = "Procurar...";
        btnBrowse.UseVisualStyleBackColor = false;
        btnBrowse.Click += btnBrowse_Click;
        // 
        // txtFilePath
        // 
        txtFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtFilePath.Font = new Font("Segoe UI", 10F);
        txtFilePath.Location = new Point(20, 59);
        txtFilePath.Name = "txtFilePath";
        txtFilePath.PlaceholderText = "Selecione o arquivo .txt que será importado";
        txtFilePath.Size = new Size(481, 25);
        txtFilePath.TabIndex = 1;
        // 
        // lblFilePath
        // 
        lblFilePath.AutoSize = true;
        lblFilePath.Font = new Font("Segoe UI", 9F);
        lblFilePath.ForeColor = Color.FromArgb(51, 65, 85);
        lblFilePath.Location = new Point(20, 33);
        lblFilePath.Name = "lblFilePath";
        lblFilePath.Size = new Size(146, 15);
        lblFilePath.TabIndex = 0;
        lblFilePath.Text = "Caminho do arquivo SPED";
        // 
        // panelHeader
        // 
        panelHeader.BackColor = Color.FromArgb(15, 23, 42);
        panelHeader.Controls.Add(lblHeaderBadge);
        panelHeader.Controls.Add(lblSubtitle);
        panelHeader.Controls.Add(lblTitle);
        panelHeader.Dock = DockStyle.Fill;
        panelHeader.Location = new Point(0, 0);
        panelHeader.Margin = new Padding(0);
        panelHeader.Name = "panelHeader";
        panelHeader.Padding = new Padding(24, 18, 24, 18);
        panelHeader.Size = new Size(547, 103);
        panelHeader.TabIndex = 0;
        // 
        // lblHeaderBadge
        // 
        lblHeaderBadge.AutoSize = true;
        lblHeaderBadge.BackColor = Color.FromArgb(30, 41, 59);
        lblHeaderBadge.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblHeaderBadge.ForeColor = Color.FromArgb(125, 211, 252);
        lblHeaderBadge.Location = new Point(947, 22);
        lblHeaderBadge.Name = "lblHeaderBadge";
        lblHeaderBadge.Padding = new Padding(10, 6, 10, 6);
        lblHeaderBadge.Size = new Size(215, 27);
        lblHeaderBadge.TabIndex = 2;
        lblHeaderBadge.Text = "Validação atual: leiaute 020 / 2026";
        // 
        // lblSubtitle
        // 
        lblSubtitle.AutoSize = true;
        lblSubtitle.Font = new Font("Segoe UI", 10F);
        lblSubtitle.ForeColor = Color.FromArgb(191, 219, 254);
        lblSubtitle.Location = new Point(28, 52);
        lblSubtitle.Name = "lblSubtitle";
        lblSubtitle.Size = new Size(43, 19);
        lblSubtitle.TabIndex = 1;
        lblSubtitle.Text = "Teste.";
        lblSubtitle.Click += lblSubtitle_Click;
        // 
        // lblTitle
        // 
        lblTitle.AutoSize = true;
        lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
        lblTitle.ForeColor = Color.White;
        lblTitle.Location = new Point(16, 0);
        lblTitle.Name = "lblTitle";
        lblTitle.Size = new Size(220, 41);
        lblTitle.TabIndex = 0;
        lblTitle.Text = "SPED Importer";
        // 
        // layoutRoot
        // 
        layoutRoot.ColumnCount = 12;
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.1993256F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.6756757F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.23648643F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.6756757F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.7601351F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.8445946F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.87162161F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.7601351F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.2736483F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 8.333333F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.6756757F));
        layoutRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.5810814F));
        layoutRoot.Controls.Add(panelHeader, 0, 0);
        layoutRoot.Controls.Add(cardFile, 0, 1);
        layoutRoot.Controls.Add(cardAction, 8, 1);
        layoutRoot.Controls.Add(cardSummary, 0, 2);
        layoutRoot.Controls.Add(cardHistory, 0, 3);
        layoutRoot.Controls.Add(cardLog, 0, 4);
        layoutRoot.Dock = DockStyle.Fill;
        layoutRoot.Location = new Point(0, 0);
        layoutRoot.Name = "layoutRoot";
        layoutRoot.RowCount = 5;
        layoutRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 103F));
        layoutRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 159F));
        layoutRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
        layoutRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        layoutRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
        layoutRoot.Size = new Size(1184, 861);
        layoutRoot.TabIndex = 0;
        layoutRoot.Paint += layoutRoot_Paint;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(241, 245, 249);
        ClientSize = new Size(1184, 861);
        Controls.Add(layoutRoot);
        MinimumSize = new Size(1080, 780);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "SPED Importer";
        Load += MainForm_Load;
        cardLog.ResumeLayout(false);
        cardLog.PerformLayout();
        cardHistory.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvRecentImports).EndInit();
        cardSummary.ResumeLayout(false);
        summaryLayout.ResumeLayout(false);
        summaryLayout.PerformLayout();
        cardAction.ResumeLayout(false);
        cardAction.PerformLayout();
        cardFile.ResumeLayout(false);
        cardFile.PerformLayout();
        panelHeader.ResumeLayout(false);
        panelHeader.PerformLayout();
        layoutRoot.ResumeLayout(false);
        ResumeLayout(false);
    }

    private GroupBox cardLog;
    private TableLayoutPanel layoutRoot;
    private Panel panelHeader;
    private Label lblHeaderBadge;
    private Label lblSubtitle;
    private Label lblTitle;
    private GroupBox cardFile;
    private Label lblHelp;
    private Button btnBrowse;
    private TextBox txtFilePath;
    private Label lblFilePath;
    private GroupBox cardAction;
    private Label lblStatusValue;
    private Label lblStatusTitle;
    private Button btnImport;
    private GroupBox cardSummary;
    private TableLayoutPanel summaryLayout;
    private Label lblLastWarningsValue;
    private Label lblLastWarningsTitle;
    private Label lblLastPeriodValue;
    private Label lblLastPeriodTitle;
    private Label lblLastLayoutValue;
    private Label lblLastLayoutTitle;
    private Label lblLastLinesValue;
    private Label lblLastLinesTitle;
    private Label lblLastStatusValue;
    private Label lblLastStatusTitle;
    private Label lblLastFileValue;
    private Label lblLastFileTitle;
    private Label lblLastIdValue;
    private Label lblLastIdTitle;
    private GroupBox cardHistory;
    private Label lblHistoryCount;
    private DataGridView dgvRecentImports;
    private TextBox txtLog;
}
