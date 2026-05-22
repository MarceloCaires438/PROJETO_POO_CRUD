# Gerenciador de Tarefas - CRUD em C#

Projeto console desenvolvido em C# com integração ao SQL Server para gerenciamento de tarefas utilizando operações CRUD.

## Funcionalidades

- Adicionar tarefas
- Listar tarefas
- Editar tarefas
- Concluir tarefas
- Excluir tarefas

## Tecnologias utilizadas

- C#
- .NET
- SQL Server
- Programação Orientada a Objetos

## Configuração do Banco de Dados

Execute o arquivo `database.sql` no SQL Server para criar o banco de dados e a tabela utilizada pelo sistema.

A connection string pode ser alterada no arquivo:

```csharp
TarefaRepository.cs
```

Exemplo:

```csharp
Server=localhost\\SQLEXPRESS;Database=CrudTarefas;Trusted_Connection=True;
```

## Como executar

1. Clone o repositório
2. Execute o script `database.sql`
3. Ajuste a connection string conforme seu SQL Server
4. Execute o projeto no Visual Studio

## Objetivo

Projeto desenvolvido para prática de Programação Orientada a Objetos, manipulação de banco de dados e operações CRUD utilizando C#.