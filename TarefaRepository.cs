using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using PROJETO_POO_CRUD.Models;

namespace PROJETO_POO_CRUD.Repository
{
    public class TarefaRepository
    {
        private readonly string conexao = "Server=.\\SQLEXPRESS;Database=TodoListDB;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";

        public void Inserir(Tarefa tarefa)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string query = "INSERT INTO TAREFAS (TAREFA, DESCRICAO, DATA_CRIACAO, CONCLUIDA) VALUES (@TAREFA, @DESCRICAO, GETDATE(), 0)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@TAREFA", tarefa.TextoTarefa);
                cmd.Parameters.AddWithValue("@DESCRICAO", (object)tarefa.Descricao ?? DBNull.Value);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n[✓] Tarefa adicionada com sucesso!");
            }
        }

        public List<Tarefa> Listar()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            using (SqlConnection con = new SqlConnection(conexao))
            {
                
                string query = "SELECT ID, TAREFA, DESCRICAO, DATA_CRIACAO, CONCLUIDA FROM TAREFAS";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tarefas.Add(new Tarefa
                        {
                            Id = (int)reader["ID"],
                            TextoTarefa = reader["TAREFA"].ToString(),
                            Descricao = reader["DESCRICAO"]?.ToString(),
                            DataCriacao = (DateTime)reader["DATA_CRIACAO"],
                            Concluida = (bool)reader["CONCLUIDA"]
                        });
                    }
                }
            }
            return tarefas;
        }

        public void Excluir(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string query = "DELETE FROM TAREFAS WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                int lines = cmd.ExecuteNonQuery();
                if (lines == 0) Console.WriteLine("\n[X] Tarefa não encontrada.");
                else Console.WriteLine("\n[✓] Tarefa excluída com sucesso!");
            }
        }

        public void MarcarComoConcluida(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string query = "UPDATE TAREFAS SET CONCLUIDA = 1 WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                int lines = cmd.ExecuteNonQuery();
                if (lines == 0) Console.WriteLine("\n[X] Tarefa não encontrada.");
                else Console.WriteLine("\n[✓] Tarefa marcada como concluída!");
            }
        }

        public void Editar(Tarefa tarefa)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                List<string> campos = new List<string>();
                SqlCommand cmd = new SqlCommand();

                if (!string.IsNullOrEmpty(tarefa.TextoTarefa))
                {
                    campos.Add("TAREFA = @TAREFA");
                    cmd.Parameters.AddWithValue("@TAREFA", tarefa.TextoTarefa);
                }
                if (!string.IsNullOrEmpty(tarefa.Descricao))
                {
                    campos.Add("DESCRICAO = @DESCRICAO");
                    cmd.Parameters.AddWithValue("@DESCRICAO", tarefa.Descricao);
                }
                if (campos.Count == 0) return;

                string query = $"UPDATE TAREFAS SET {string.Join(", ", campos)} WHERE ID = @ID";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ID", tarefa.Id);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("\n[✓] Tarefa atualizada com sucesso!");
            }
        }
    }
}
