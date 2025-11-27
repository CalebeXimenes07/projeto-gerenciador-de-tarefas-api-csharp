# Gerenciador de Tarefas - API REST com .NET 8

Este repositório contém uma API RESTful desenvolvida utilizando o framework .NET 8. O objetivo do projeto é fornecer um sistema backend robusto para o agendamento e gerenciamento de tarefas, implementando operações de CRUD (Create, Read, Update, Delete) completas.

A aplicação utiliza o Entity Framework Core para persistência de dados em SQL Server e segue padrões de desenvolvimento modernos para construção de APIs, incluindo documentação via Swagger.

## Tecnologias Utilizadas

- **.NET 8 SDK**
- **C# 12**
- **Entity Framework Core** (ORM)
- **Microsoft SQL Server** (Banco de Dados)
- **Swagger / OpenAPI** (Documentação Interativa)
- **Docker** (Opcional, para execução do banco de dados em contêiner)

## Pré-requisitos do Ambiente

Para compilar e executar o projeto, o ambiente de desenvolvimento deve possuir:

1. **.NET SDK 8.0** ou superior instalado.
2. **Git** configurado.
3. **SQL Server** em execução.
   - Pode ser uma instância local (Windows).
   - Pode ser uma instância via Docker (Linux/Mac/Windows).
4. **Editor de Código/IDE** (Visual Studio Code ou Visual Studio 2022).

## Configuração da Conexão com Banco de Dados

A aplicação requer uma string de conexão válida para operar. Antes de iniciar, é necessário configurar o acesso ao banco de dados.

1. Localize o arquivo `appsettings.json` na raiz do projeto.
2. Na seção `ConnectionStrings`, configure a chave `DefaultConnection` com as credenciais do seu ambiente.

Exemplo de configuração padrão (compatível com Docker e SQL Server Authentication):

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=GerenciadorTarefasDb;User Id=sa;Password=SuaSenhaForte!;TrustServerCertificate=True;"
}
```

*Nota: A propriedade 'TrustServerCertificate=True' é obrigatória para ambientes de desenvolvimento utilizando contêineres Docker (Linux/Mac) para ignorar a validação de certificado SSL.*

## Instalação e Execução

Siga os passos abaixo para configurar o projeto em sua máquina local:

### 1. Clonar o Repositório

```bash
git clone https://github.com/CalebeXimenes07/NOME-DO-SEU-REPOSITORIO.git
```

### 2. Acessar o Diretório

```bash
cd NOME-DO-SEU-REPOSITORIO
```

### 3. Restaurar Dependências (NuGet)

Baixe todas as bibliotecas necessárias para o funcionamento do projeto:

```bash
dotnet restore
```

### 4. Executar Migrações (Criação do Banco)

O projeto utiliza a abordagem Code First. Execute o comando abaixo para que o Entity Framework crie o banco de dados e a tabela `Tarefas` automaticamente:

```bash
dotnet ef database update
```

### 5. Iniciar a Aplicação

```bash
dotnet run
```

Após a inicialização, a API estará ouvindo nas portas configuradas. Por padrão, o endereço de acesso é `http://localhost:5183`.

## Documentação da API (Swagger)

A aplicação possui interface visual do Swagger habilitada. Com a aplicação rodando, acesse o seguinte endereço no navegador para testar os endpoints:

**URL:** http://localhost:5183/swagger

## Endpoints da API

Abaixo estão detalhados todos os endpoints disponíveis, seus métodos HTTP e os formatos de dados esperados.

### Criar Tarefa
Adiciona um novo registro ao banco de dados.

- **Método:** `POST`
- **Rota:** `/Tarefa`
- **Corpo da Requisição (JSON):**
```json
{
  "titulo": "Estudar C#",
  "descricao": "Estudar sobre API e Entity Framework",
  "data": "2025-11-26T14:00:00",
  "status": false
}
```

### Obter por ID
Retorna os detalhes de uma tarefa específica.

- **Método:** `GET`
- **Rota:** `/Tarefa/{id}`
- **Exemplo:** `/Tarefa/1`

### Listar Todas
Retorna a lista completa de tarefas cadastradas no banco.

- **Método:** `GET`
- **Rota:** `/Tarefa/ObterTodos`

### Buscar por Título
Filtra tarefas que contenham o texto especificado (busca parcial).

- **Método:** `GET`
- **Rota:** `/Tarefa/ObterPorTitulo/{titulo}`
- **Exemplo:** `/Tarefa/ObterPorTitulo/Estudar`

### Buscar por Data
Filtra tarefas agendadas para uma data específica (ignorando o horário).

- **Método:** `GET`
- **Rota:** `/Tarefa/ObterPorData/{data}`
- **Formato da Data:** YYYY-MM-DD
- **Exemplo:** `/Tarefa/ObterPorData/2025-11-26`

### Buscar por Status
Filtra tarefas baseadas no estado de conclusão.

- **Método:** `GET`
- **Rota:** `/Tarefa/ObterPorStatus/{status}`
- **Parâmetro:** `true` (Concluídas) ou `false` (Pendentes)
- **Exemplo:** `/Tarefa/ObterPorStatus/false`

### Atualizar Tarefa
Atualiza os dados de um registro existente. É necessário enviar o objeto completo.

- **Método:** `PUT`
- **Rota:** `/Tarefa/{id}`
- **Corpo da Requisição:** JSON idêntico ao de criação, porém referenciando o ID na URL.

### Excluir Tarefa
Remove permanentemente um registro do banco de dados.

- **Método:** `DELETE`
- **Rota:** `/Tarefa/{id}`

## Solução de Problemas Comuns

**Erro: "Login failed for user 'sa'"**
Verifique se a senha no `appsettings.json` é **exatamente igual** à senha definida na criação do contêiner Docker ou na instalação do SQL Server.

**Erro: "SSL Provider: Error 35"**
Isso ocorre no Linux ao conectar com SQL Server local. Certifique-se de que sua Connection String possui `TrustServerCertificate=True;`.

**Erro: "Invalid object name 'Tarefas'"**
O banco de dados foi conectado, mas a tabela não existe. Execute o comando `dotnet ef database update` para aplicar as migrações.

**Erro: "AmbiguousMatchException"**
Isso ocorre se as rotas estiverem conflitantes. Certifique-se de que os métodos no Controller possuem rotas distintas como `ObterPorData/{data}` e `ObterPorTitulo/{titulo}`.

## Autor

Desenvolvido por **Calebe Ximenes**.
GitHub: [https://github.com/CalebeXimenes07](https://github.com/CalebeXimenes07)
