using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class crudListado
    {
        public static int deleteCaballoDAL(int id)

        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = "server=davidser.database.windows.net;database=DavidDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
            miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
            try
            {
                miConexion.Open();
                miComando.CommandText = "DELETE FROM Caballos WHERE ID=@id";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return numeroFilasAfectadas;

        }
    }
}
