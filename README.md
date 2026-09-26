# SPED Importer

Aplicação desenvolvida em **C# com .NET 10** para importação, processamento e persistência de arquivos **SPED Fiscal**, com foco em organização, separação de responsabilidades e facilidade de manutenção.

O projeto utiliza uma arquitetura dividida em camadas, **Entity Framework Core** para acesso a dados, **MySQL** como banco de dados e uma interface desktop desenvolvida com **Windows Forms**.

---

## Sobre o projeto

O **SPED Importer** tem como objetivo facilitar a leitura e o processamento de arquivos do **Sistema Público de Escrituração Digital (SPED)**.

A aplicação interpreta os registros presentes no arquivo fiscal, transforma os dados em entidades da aplicação e permite sua persistência em banco de dados.

Além da funcionalidade de importação, o projeto foi estruturado buscando aplicar boas práticas de desenvolvimento em .NET, como:

- Separação de responsabilidades;
- Arquitetura em camadas;
- Injeção de dependência;
- Persistência utilizando Entity Framework Core;
- Processamento assíncrono;
- Testes automatizados;
- Isolamento das regras de domínio.

---

## Funcionalidades

- Importação de arquivos SPED Fiscal;
- Leitura e processamento de registros do arquivo;
- Identificação automática dos diferentes tipos de registro;
- Conversão das linhas do SPED para entidades do domínio;
- Persistência das informações em banco MySQL;
- Interface desktop para seleção e importação dos arquivos;
- Processamento assíncrono;
- Tratamento de registros não suportados;
- Estrutura preparada para inclusão de novos registros;
- Testes automatizados das principais regras da aplicação.

---

## Registros suportados

Entre os registros implementados atualmente estão:

| Registro | Descrição |
|---|---|
| `0000` | Abertura do arquivo digital e identificação da entidade |
| `0005` | Dados complementares da entidade |
| `0100` | Dados do contabilista |
| `E100` | Período da apuração do ICMS |
| `E110` | Apuração do ICMS – operações próprias |

A arquitetura do projeto permite adicionar novos registros através da criação de suas respectivas entidades e parsers.

---

## Tecnologias utilizadas

- **C#**
- **.NET 10**
- **Windows Forms**
- **Entity Framework Core**
- **MySQL**
- **Pomelo.EntityFrameworkCore.MySql**
- **Microsoft.Extensions.DependencyInjection**
- **Microsoft.Extensions.Configuration**
- **xUnit**
- **Git**

---

## Arquitetura

O projeto foi dividido em diferentes camadas para manter as responsabilidades bem definidas:

```text
SpedImporter
│
├── SpedImporter.Domain
│   └── Entidades e regras centrais do domínio
│
├── SpedImporter.Application
│   └── Casos de uso e serviços da aplicação
│
├── SpedImporter.Infrastructure
│   ├── Persistência
│   ├── Entity Framework Core
│   └── Parsers dos registros SPED
│
├── SpedImporter.Desktop
│   └── Interface gráfica Windows Forms
│
├── SpedImporter.Runner
│   └── Execução da aplicação via console
│
└── SpedImporter.Tests
    └── Testes automatizados
```

Essa separação reduz o acoplamento entre a interface, regras da aplicação e infraestrutura.

---

## Fluxo de importação

De forma simplificada, o processamento ocorre da seguinte maneira:

```text
Arquivo SPED
     │
     ▼
Leitura das linhas
     │
     ▼
Identificação do registro
     │
     ▼
Parser correspondente
     │
     ▼
Entidade do domínio
     │
     ▼
Persistência
     │
     ▼
MySQL
```

Cada tipo de registro possui sua própria responsabilidade de interpretação, permitindo que o sistema seja expandido sem concentrar toda a lógica de parsing em uma única classe.

---

## Como executar

### Pré-requisitos

Antes de executar o projeto, tenha instalado:

- .NET 10 SDK
- MySQL
- Git

### 1. Clone o repositório

```bash
git clone https://github.com/vsdavis/SpedImporter.git
```

Entre no diretório:

```bash
cd SpedImporter
```

### 2. Restaure as dependências

```bash
dotnet restore
```

### 3. Configure o banco de dados

Crie um arquivo `appsettings.json` no projeto que será executado e configure sua conexão com o MySQL.

Exemplo:

```json
{
  "ConnectionStrings": {
    "MySql": "server=localhost;port=3306;database=sped_import;user=SEU_USUARIO;password=SUA_SENHA"
  }
}
```

> O arquivo `appsettings.json` não deve ser versionado quando possuir credenciais locais.

### 4. Crie o banco de dados

Com o MySQL em execução, aplique as migrations do Entity Framework Core conforme a configuração do ambiente.

### 5. Compile o projeto

```bash
dotnet build
```

### 6. Execute a aplicação

Para executar a interface desktop:

```bash
dotnet run --project SpedImporter.Desktop
```

---

## Testes

O projeto possui testes automatizados para validar partes importantes do processamento dos arquivos SPED.

Para executar todos os testes:

```bash
dotnet test
```


## Objetivos técnicos

Além de realizar a importação de arquivos SPED, este projeto também busca demonstrar conhecimentos em:

- Desenvolvimento com C# e .NET;
- Programação orientada a objetos;
- Arquitetura em camadas;
- Entity Framework Core;
- Banco de dados relacional;
- Dependency Injection;
- Processamento de arquivos;
- Parsing de dados estruturados;
- Programação assíncrona;
- Testes automatizados;
- Organização e manutenção de projetos .NET.

---

## Possíveis evoluções

Algumas funcionalidades que podem ser adicionadas futuramente:

- Suporte a novos registros SPED;
- Melhorias na experiência da interface;
- Relatório dos arquivos importados;
- Histórico de importações;
- Validação mais detalhada de inconsistências;
- Exportação de informações processadas;
- Dashboard com resumo dos dados importados.

---

## Autor

**David Vieira Souza**

Desenvolvedor focado no ecossistema **C# / .NET**, desenvolvimento backend, aplicações desktop e bancos de dados relacionais.

GitHub: `@vsdavis`

---

## Sobre o SPED

O **Sistema Público de Escrituração Digital (SPED)** é uma iniciativa do governo brasileiro para modernizar e digitalizar o cumprimento das obrigações fiscais e contábeis das empresas.

Este projeto possui finalidade de estudo e demonstração técnica e não substitui ferramentas oficiais de validação ou escrituração fiscal.