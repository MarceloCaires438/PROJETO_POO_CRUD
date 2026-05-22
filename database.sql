CREATE DATABASE CrudTarefas;
GO

USE CrudTarefas;
GO

CREATE TABLE Tarefas (
    Id INT PRIMARY KEY IDENTITY,
    Nome NVARCHAR(100),
    Descricao NVARCHAR(255),
    Concluida BIT
);