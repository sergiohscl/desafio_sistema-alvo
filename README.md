# 🚀 Desafio Sistema Alvo

API desenvolvida em **C# com .NET 10** para resolução de desafios envolvendo **comissões de vendedores, movimentação de estoque e cálculo de juros**.

O projeto foi desenvolvido utilizando boas práticas de desenvolvimento, separação de responsabilidades e uma arquitetura organizada em camadas.

---

## 🎯 Desafio

### 💰 1. Cálculo de Comissão

Considerando um arquivo JSON contendo registros de vendas de um time comercial, a aplicação deve ler os dados e calcular a comissão de cada vendedor.

A comissão é calculada de acordo com o valor de cada venda:

| Valor da venda | Comissão |
|---|---:|
| 💵 Abaixo de R$ 100,00 | 0% |
| 💵 De R$ 100,00 até abaixo de R$ 500,00 | 1% |
| 💵 A partir de R$ 500,00 | 5% |

A API retorna o resultado da comissão calculada para cada vendedor.

---

### 📦 2. Movimentação de Estoque

A aplicação permite realizar movimentações de estoque dos produtos cadastrados no arquivo JSON.

Cada movimentação possui:

- 🔢 Número identificador único
- 📝 Descrição da movimentação
- 📥 Entrada de mercadoria
- 📤 Saída de mercadoria
- 📦 Quantidade movimentada
- 🏷️ Identificação do produto

A aplicação também realiza validações para impedir que o estoque fique negativo.

Ao finalizar uma movimentação, a API retorna a **quantidade final disponível em estoque** para o produto movimentado.

---

### 💰 3. Cálculo de Juros

A aplicação calcula os juros de um determinado valor considerando:

- 💵 Valor original
- 📅 Data de vencimento
- 📆 Data atual
- 📈 Multa de **2,5% ao dia**

Caso o título esteja vencido, o sistema calcula o valor dos juros correspondente aos dias em atraso.

---

# 🛠️ Tecnologias utilizadas

- 🟣 **C#**
- 🟣 **.NET 10**
- 🌐 **ASP.NET Core Web API**
- 📄 **JSON**
- 🧪 **xUnit**
- 🐳 **Docker**
- ⚙️ **GitHub Actions**
- 📡 **OpenAPI**
- 🔍 **Insomnia**
- 🧹 **Ruff/boas práticas de código**
- 📦 **NuGet**

---

# 🏗️ Arquitetura

O projeto utiliza uma organização baseada na separação de responsabilidades, mantendo controllers, serviços, modelos, DTOs e tratamento de exceções separados.

```text
desafio_sistema-alvo/
│
├── 📁 Controllers/
│   ├── ComissaoController.cs
│   ├── EstoqueController.cs
│   └── JurosController.cs
│
├── 📁 Data/
│   └── 📁 JsonData/
│       ├── vendas.json
│       └── produtos.json
│
├── 📁 DTO/
│   ├── 📁 Comissao/
│   ├── 📁 Estoque/
│   └── 📁 Juros/
│
├── 📁 Exceptions/
│
├── 📁 Middlewares/
│
├── 📁 Models/
│
├── 📁 Services/
│   ├── 📁 Interfaces/
│   ├── ComissaoService.cs
│   ├── EstoqueService.cs
│   └── JurosService.cs
│
├── 📁 Tests/
│
├── 📄 Program.cs
├── 📄 Dockerfile
├── 📄 docker-compose.yml
├── 📄 desafio_sistema-alvo.csproj
└── 📄 README.md
```

---

# 📋 Pré-requisitos

Antes de executar o projeto, certifique-se de possuir:

- 🟣 .NET SDK 10
- 🐳 Docker
- 🐙 Git
- 🔍 Insomnia ou outra ferramenta para testes de API

Verifique a versão do .NET:

```bash
dotnet --version
```

---

# 📥 Como clonar o projeto

Clone o repositório:

```bash
git clone https://github.com/sergiohscl/desafio_sistema-alvo.git
```

Entre no diretório:

```bash
cd desafio_sistema-alvo
```

---

# ▶️ Executando localmente

Restaure as dependências:

```bash
dotnet restore
```

Compile o projeto:

```bash
dotnet build
```

Execute a aplicação:

```bash
dotnet run
```

A API ficará disponível na porta informada pelo ASP.NET Core.

---

# 🐳 Executando com Docker

Para criar a imagem:

```bash
docker build -t desafio-sistema-alvo:latest .
```

Para executar utilizando Docker Compose:

```bash
docker compose up -d
```

Verifique os containers:

```bash
docker ps
```

Para acompanhar os logs:

```bash
docker compose logs -f
```

Para parar os containers:

```bash
docker compose down
```

---

# 📦 Pacotes utilizados

Principais pacotes utilizados no projeto:

### 🌐 ASP.NET Core

Utilizado para construção da API REST.

```text
Microsoft.AspNetCore.OpenApi
```

### 🧪 Testes

Utilizado para criação e execução dos testes automatizados:

```text
xUnit
Microsoft.NET.Test.Sdk
```

---

# 🧪 Executando os testes

Para executar todos os testes:

```bash
dotnet test
```

Para executar com informações detalhadas:

```bash
dotnet test --verbosity normal
```

Os testes validam as principais regras de negócio da aplicação.

---

# 🔌 API

A aplicação utiliza o prefixo:

```text
/api/v1
```

### 💰 Comissão

Endpoint responsável pelo cálculo das comissões:

```http
GET /api/v1/comissao
```

---

### 📦 Estoque

Endpoint responsável pelas movimentações de estoque:

```http
POST /api/v1/estoque
```

A movimentação pode representar:

```text
📥 ENTRADA
📤 SAÍDA
```

O sistema valida a existência do produto e impede movimentações que resultariam em estoque negativo.

---

### 💵 Juros

Endpoint responsável pelo cálculo dos juros:

```http
POST /api/v1/juros
```

Recebe o valor e a data de vencimento e retorna o cálculo correspondente aos dias de atraso.

---

# 📄 Dados utilizados

Os dados utilizados pela aplicação são armazenados em arquivos JSON dentro de:

```text
Data/JsonData/
```

Exemplo:

```text
Data/
└── JsonData/
    ├── vendas.json
    └── produtos.json
```

Isso permite manter os dados de entrada separados da lógica de negócio.

---

# 🔐 Tratamento de erros

A aplicação possui um middleware global para tratamento de exceções.

Com isso, erros de negócio e exceções inesperadas são tratados de forma centralizada, evitando duplicação de código nos controllers.

Exemplos de situações tratadas:

- ❌ Produto não encontrado
- ❌ Estoque insuficiente
- ❌ Dados inválidos
- ❌ Erros inesperados da aplicação

---

# 🔄 CI/CD

O projeto possui uma esteira de **CI/CD utilizando GitHub Actions**.

### 🔵 CI — Integração Contínua

A cada alteração enviada para o GitHub, são executados processos como:

```text
📥 Checkout
   ↓
📦 Restore
   ↓
🔨 Build
   ↓
🧪 Testes
```

### 🟢 CD — Entrega Contínua

Após a validação do projeto, a pipeline realiza o processo de build e publicação da imagem Docker.

```text
Git Push
   ↓
GitHub Actions
   ↓
Build
   ↓
Testes
   ↓
Docker Build
   ↓
Docker Image
   ↓
Docker Hub
```

---

# 🐳 Docker Hub

A aplicação também possui uma imagem Docker publicada no Docker Hub.

Imagem:

```text
sergiohscl/desafio-sistema-alvo:latest
```

---

# 🧠 Boas práticas utilizadas

O projeto foi desenvolvido buscando aplicar princípios de desenvolvimento de software, como:

- ✅ Separação de responsabilidades
- ✅ Injeção de dependência
- ✅ DTOs
- ✅ Interfaces
- ✅ Services
- ✅ Controllers enxutos
- ✅ Middleware global de exceções
- ✅ Validação das regras de negócio
- ✅ Testes automatizados
- ✅ Containerização com Docker
- ✅ CI/CD
- ✅ Versionamento com Git

---

# 📌 Objetivo do projeto

Este projeto foi desenvolvido como desafio técnico com o objetivo de demonstrar conhecimentos em:

- 💻 Desenvolvimento de APIs REST
- 🟣 C# / .NET
- 🏗️ Arquitetura de software
- 🧠 Regras de negócio
- 🧪 Testes automatizados
- 🐳 Docker
- ⚙️ CI/CD
- 🔄 Git/GitHub
- 📦 Organização e manutenção de código

---

## 👨‍💻 Autor

**Sergio Henrique**

Desenvolvido com foco em **boas práticas, organização de código, arquitetura limpa e qualidade de software**. 🚀

⭐ Se este projeto foi útil ou interessante, considere deixar uma estrela no repositório!