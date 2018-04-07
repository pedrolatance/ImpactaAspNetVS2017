create PROCEDURE TarefaExcluir
	@id int

as
BEGIN

DELETE FROM [dbo].[tarefa]
WHERE [Id] = @id

END
