using APIBoletim.Context;
using APIBoletim.Domains;
using APIBoletim.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIBoletim.Repositories
{
    public class AlunoRepository : IAluno
    {
        //Chama a classe de conexão do Banco
        BoletimContext conexao = new BoletimContext();

        //Chama o obj que irá receber e executar os comando do Banco
        SqlCommand cmd = new SqlCommand();

        public Aluno Alterar(Aluno a)
        {
            throw new NotImplementedException();
        }

        public Aluno BuscarPorID(int id)
        {
            throw new NotImplementedException();
        }

        public Aluno Cadastrar(Aluno a)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ListarTodos()
        {
            //Abrir a conexão
            cmd.Connection = conexao.Conectar();

            //Preparar consulta - query
            cmd.CommandText = "SELECT * FROM Aluno";

            SqlDataReader dados = cmd.ExecuteReader();

            //Fechar a conexão
            conexao.Desconectar();
        }

        public Aluno Remover(Aluno a)
        {
            throw new NotImplementedException();
        }
    }
}
