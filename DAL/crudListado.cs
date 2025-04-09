using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class crudListado
    {
        /// <summary>
        /// delete del caballo de la BDD
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                miComando.CommandText = "DELETE FROM Caballos WHERE IDCaballo=@id";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();

            }

            catch (Exception ex)

            {

                throw ex;

            }

            return numeroFilasAfectadas;

        }
        /// <summary>
        /// update del caballo de la BDD
        /// </summary>
        /// <param name="caballoEditado"></param>
        /// <returns></returns>
        public static bool editarCaballo(clsCaballo caballoEditado)
        {
            bool haEditado = false;
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = "server=davidser.database.windows.net;database=DavidDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";

            miComando.Parameters.Add("@idCaballo", System.Data.SqlDbType.Int).Value = caballoEditado.IdCaballo;
            miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = caballoEditado.Nombre;
            miComando.Parameters.Add("@idRaza", System.Data.SqlDbType.Int).Value = caballoEditado.IdRaza;

            try
            {
                miConexion.Open();
                miComando.CommandText = "UPDATE Caballos SET Nombre=@Nombre, IDRaza=@idRaza WHERE IDCaballo=@idCaballo;";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
                haEditado = numeroFilasAfectadas > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }
            return haEditado;
        }
        /// <summary>
        /// Crea un nuevo caballo en la BDD
        /// </summary>
        /// <param name="nuevoCaballo"></param>
        /// <returns></returns>
        public static int crearCaballo(clsCaballo nuevoCaballo)
        {
            int numeroFilasAfectadas = 0;
            SqlConnection miConexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            miConexion.ConnectionString = "server=davidser.database.windows.net;database=DavidDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";

            miComando.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar).Value = nuevoCaballo.Nombre;
            miComando.Parameters.Add("@idRaza", System.Data.SqlDbType.Int).Value = nuevoCaballo.IdRaza;

            try
            {
                miConexion.Open();
                miComando.CommandText = "INSERT INTO Caballos (Nombre, IDRaza) VALUES (@Nombre, @idRaza);";
                miComando.Connection = miConexion;
                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                miConexion.Close();
            }

            return numeroFilasAfectadas;
        }

    }
}
