using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace SiteBD.Repositorio
{
    public class Contexto :IDisposable
    {
        private readonly SqlConnection minhaconexao;
        public Contexto()
        {
            const string stringConexao = @"data source=VINICIOS;Integrated Security=SSPI;Initial Catalog=ChuckNorris";
             minhaconexao = new SqlConnection(stringConexao);
             minhaconexao.Open();
        }
        public void ExecutaComando(string strQuery)
        {

            var comando = new SqlCommand(strQuery, minhaconexao);
            comando.ExecuteNonQuery();

        }

        public SqlDataReader Executacomandocomretorno(string strQuery)
        {
            var comando = new SqlCommand(strQuery, minhaconexao);
            return comando.ExecuteReader();

        }

        public void Dispose()
        {
            if (minhaconexao.State ==ConnectionState.Open)
                minhaconexao.Close();
        }
    }
}