using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace API_Pets.Context
{
    public class ClinicasContext
    {
        SqlConnection con = new SqlConnection();

        public ClinicasContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-D5U2PUB\SQLEXPRESS;Initial Catalog=clinica;Persist Security Info=True;User ID=sa;Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if(con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }

        //Void não possui retorno
        public void Desconectar()
        {
            if(con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
