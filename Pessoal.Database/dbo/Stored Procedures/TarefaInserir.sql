CREATE PROCEDURE [dbo].[TarefaInserir] 
	@nome nvarchar(200),
	@prioridade int,
	@concluida bit,
	@observacao nvarchar(1000)
AS
BEGIN
-- Insert statements for procedure here
INSERT INTO [dbo].[tarefa]
			([Nome]
			,[Prioridade]
			,[Concluida]
			,[Observacao])
OUTPUT inserted.Id
VALUES
    (@nome
    ,@prioridade
    ,@concluida
    ,@observacao)
END
