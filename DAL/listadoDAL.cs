using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENT;
using Microsoft.Data.SqlClient;
using Services;

namespace DAL
{
    public class listadoDAL
    {
        /// <summary>
        /// Obtiene un listado de caballos de la BDD
        /// </summary>
        /// <returns></returns>
        public static List<clsCaballo> ObtenerCaballos()
        {

            SqlConnection miConexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();
            clsCaballo oCaballo;
            List<clsCaballo> listadoCaballos = new List<clsCaballo>();

            try
            {
                miConexion = clsConexionListado.getConexion();
                //miConexion.Open();
                miComando.CommandText = "SELECT * FROM caballos";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        int idCaballo = (int)miLector["IDCaballo"];
                        oCaballo = new clsCaballo(idCaballo);

                        if (miLector["Nombre"] != DBNull.Value)
                        {
                            oCaballo.Nombre = (string)miLector["Nombre"];
                        }
                        if (miLector["IDRaza"] != DBNull.Value)
                        {
                            oCaballo.IdRaza = (int)miLector["IDRaza"];
                        }
                        listadoCaballos.Add(oCaballo);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }

            return listadoCaballos;
        }
        public static List<clsRaza> ObtenerRazas()
        {
            SqlConnection miConexion;
            SqlDataReader miLector;
            SqlCommand miComando = new SqlCommand();
            clsRaza oRaza;
            List<clsRaza> listadoRazas = new List<clsRaza>();

            try
            {
                miConexion = clsConexionListado.getConexion();
                miComando.CommandText = "SELECT * FROM Razas";
                miComando.Connection = miConexion;
                miLector = miComando.ExecuteReader();

                if (miLector.HasRows)
                {
                    while (miLector.Read())
                    {
                        int idRaza = (int)miLector["IDRaza"];
                        oRaza = new clsRaza(idRaza, (string)miLector["Nombre"]);
                        listadoRazas.Add(oRaza);
                    }
                }

                miLector.Close();
                miConexion.Close();
            }
            catch (SqlException SqlEx)
            {
                throw SqlEx;
            }

            return listadoRazas;
        }

        public static clsCaballo BuscarCaballoPorRaza(int id)
        {
            string connectionString = "server=davidser.database.windows.net;database=DavidDB;uid=usuario;pwd=LaCampana123;trustServerCertificate=true;";
            clsCaballo oCaballo=null;

            using (SqlConnection miConexion = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Caballos WHERE IDRaza = @id";

                using (SqlCommand miComando = new SqlCommand(query, miConexion))
                {
                    miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;

                    try
                    {
                        miConexion.Open();

                        using (SqlDataReader miLector = miComando.ExecuteReader())
                        {
                            if (miLector.Read())
                            {
                                {
                                    int idCaballo = (int)miLector["IDCaballo"];
                                    oCaballo = new clsCaballo(idCaballo);
                                    oCaballo.Nombre = (string)miLector["Nombre"];
                                    oCaballo.IdRaza = (int)miLector["IDRaza"];
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        throw ex;
                    }
                }
            }

            return oCaballo;
        }

    }
}
