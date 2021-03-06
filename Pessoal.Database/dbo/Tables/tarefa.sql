﻿CREATE TABLE [dbo].[tarefa] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [Nome]       NVARCHAR (200)  NOT NULL,
    [Prioridade] INT             NOT NULL,
    [Concluida]  BIT             NOT NULL,
    [Observacao] NVARCHAR (1000) NULL,
    CONSTRAINT [PK_tarefa] PRIMARY KEY CLUSTERED ([Id] ASC)
);

