using API_Pets.Context;
using API_Pets.Domains;
using API_Pets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API_Pets.Repositories
{
    public class ClinicasRepository : IClinicas
    {
        ClinicasContext conexao = new ClinicasContext();
        SqlCommand cmd = new SqlCommand();

        public Clinicas Alterar(int id, Clinicas c)
        {
            //Abrir conexão
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE clinicas SET " +
                "Nome = @nome, " +
                "Endereco = @endereco WHERE IdClinicas = @id";

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@endereco", c.Endereco);
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            //Fechar conexão
            conexao.Desconectar();

            return c;
        }

        public Clinicas BuscarPorID(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM clinicas WHERE IdClinicas = @id";
            //Atribui a variável q vem com o argumento
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            Clinicas c = new Clinicas();

            while (dados.Read())
            {
                c.IdClinicas    = Convert.ToInt32(dados.GetValue(0));
                c.Nome          = dados.GetValue(1).ToString();
                c.Endereco      = dados.GetValue(2).ToString();
            }

            conexao.Desconectar();

            return c;
        }

        public Clinicas Cadastrar(Clinicas c)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO clinicas (Nome, Endereco)" +
                "VALUES" +
                "(@nome, @endereco)";

            cmd.Parameters.AddWithValue("@nome", c.Nome);
            cmd.Parameters.AddWithValue("@endereco", c.Endereco);

            //Comando que insere os dados no banco
            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return c;
        }

        public List<Clinicas> ListarTodos()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM clinicas";

            SqlDataReader dados = cmd.ExecuteReader();

            List<Clinicas> clinicas = new List<Clinicas>();

            while (dados.Read())
            {
                clinicas.Add(
                    new Clinicas()
                    {
                        IdClinicas  = Convert.ToInt32(dados.GetValue(0)),
                        Nome        = dados.GetValue(1).ToString(),
                        Endereco    = dados.GetValue(2).ToString()
                    }
                );
            }

            conexao.Desconectar();

            return clinicas;
        }

        public void Remover(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM clinicas WHERE IdClinicas = @id";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();
        }
    }
}
