﻿using Pessoal.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Pessoal.Repositorios.SqlServer
{
    public class TarefaRepositorio
    {
        private string _stringConexao = ConfigurationManager.ConnectionStrings["pessoalConnectionString"].ConnectionString;


        public int Inserir(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaInserir";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa));
                    return (int)comando.ExecuteScalar();
                }

            }
        }

        public void Atualizar(Tarefa tarefa)
        {
            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaAtualizar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddRange(Mapear(tarefa));
                    comando.ExecuteNonQuery();
                }

            }
        }

        public List<Tarefa> Selecionar()
        {
            var tarefas = new List<Tarefa>();

            using (var conexao = new SqlConnection(_stringConexao))
            {
                conexao.Open();

                const string nomeProcedure = "TarefaSelecionar";

                using (var comando = new SqlCommand(nomeProcedure, conexao))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (var registro = comando.ExecuteReader())
                    {
                        while (registro.Read())
                        {
                            tarefas.Add(Mapear(registro));
                        }
                    }
                }
            }

            return tarefas;
        }

        private Tarefa Mapear(SqlDataReader registro)
        {
            throw new NotImplementedException();
        }

        private SqlParameter[] Mapear(Tarefa tarefa)
        {
            var parametros = new List<SqlParameter>();

            if (tarefa.Id != 0)
            {
                parametros.Add(new SqlParameter("@id", tarefa.Id));
            }

            parametros.Add(new SqlParameter("@nome", tarefa.Nome));
            parametros.Add(new SqlParameter("@prioridade", tarefa.Prioridade));
            parametros.Add(new SqlParameter("@concluida", tarefa.Concluida));
            parametros.Add(new SqlParameter("@observacao", tarefa.Observacao));

            return parametros.ToArray();
        }


    }
}
