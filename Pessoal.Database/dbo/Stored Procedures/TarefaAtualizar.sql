create PROCEDURE TarefaAtualizar
	@id int,
	@nome nvarchar(200),
	@prioridade int,
	@concluida bit,
	@observacao nvarchar(1000)
AS
BEGIN

UPDATE [dbo].[tarefa]
	SET [Nome] = @nome,
		[Prioridade] = @prioridade,
		[Concluida] = @concluida,
		[Observacao] = @observacao
where [Id] = @id
END
