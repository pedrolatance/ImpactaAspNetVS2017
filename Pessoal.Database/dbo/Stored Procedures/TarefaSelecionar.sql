create PROCEDURE TarefaSelecionar
	@id int = null

as
BEGIN

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacao]
  FROM [dbo].[tarefa]

  where [Id] = ISNULL(@id, Id)
  order by Concluida, Prioridade
END
