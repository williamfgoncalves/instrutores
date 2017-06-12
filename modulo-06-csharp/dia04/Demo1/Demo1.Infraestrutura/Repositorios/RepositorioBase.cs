using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1.Infraestrutura.Repositorios
{
    public abstract class RepositorioBase
    {
        readonly string _connectionString;

        public RepositorioBase()
        {
            /*
            * https://www.connectionstrings.com/sqlconnection/
            * Server=myServerAddress;
            * Database=myDataBase;
            * User Id = myUsername;
            * Password=myPassword;
            */
            _connectionString =
                        @"Server=13.65.101.67;
                        User Id=giovani;
                        Password=123456;
                        Database=aluno26db";
        }
        protected SqlConnection CriarConexao()
        {
            var conexao = new SqlConnection(_connectionString);
            conexao.Open();
            return conexao;
        }
    }
}
