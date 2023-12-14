using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Entidades;

namespace EntidadesDAO
{
    public static class ProvincialDAO
    {
        static string cadenaconexion;
        static SqlConnection conexion;
        static SqlCommand comando;

        static ProvincialDAO()
        {
            cadenaconexion = "Server=.;Database=Centralita;Trusted_Connection=True;\r\n";
            conexion = new SqlConnection(cadenaconexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static void Guardar(Provincial provincial)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "" +
                    "INSERT INTO Llamadas (Duracion, Origen, Destino, Costo, Tipo)" +
                    "VALUES (@duracion, @origen, @destino, @costo, @tipo);";
                comando.Parameters.AddWithValue("@duracion", provincial.Duracion);
                comando.Parameters.AddWithValue("@origen", provincial.NroOrigen);
                comando.Parameters.AddWithValue("@destino", provincial.NroDestino);
                comando.Parameters.AddWithValue("@costo", provincial.CostoLlamada);
                comando.Parameters.AddWithValue("@tipo", 1);
                comando.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }
        }

        public static List<Provincial> Leer()
        {
            List<Provincial> list = new List<Provincial>();
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM Llamadas WHERE Tipo = 1;";
                using(SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Provincial(
                            (float)Convert.ToDouble(reader["Duracion"]),
                            Provincial.Franja.Franja_1,
                            reader["Destino"].ToString(),
                            reader["Origen"].ToString()
                            ));
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conexion.Close();
            }
            return list;
        }
    }
}
