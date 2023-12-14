using Entidades;
using Microsoft.Data.SqlClient;

namespace EntidadesDAO
{
    public class LocalDAO
    {
        static string cadenaconexion;
        static SqlConnection conexion;
        static SqlCommand comando;

        static LocalDAO()
        {
            cadenaconexion = "Server=.;Database=Centralita;Trusted_Connection=True;\r\n";
            conexion = new SqlConnection(cadenaconexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static void Guardar(Local local)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "" +
                    "INSERT INTO Llamadas (Duracion, Origen, Destino, Costo, Tipo)" +
                    "VALUES (@duracion, @origen, @destino, @costo, @tipo);";
                comando.Parameters.AddWithValue("@duracion", local.Duracion);
                comando.Parameters.AddWithValue("@origen", local.NroOrigen);
                comando.Parameters.AddWithValue("@destino", local.NroDestino);
                comando.Parameters.AddWithValue("@costo", local.CostoLlamada);
                comando.Parameters.AddWithValue("@tipo", 0);
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

        public static List<Local> Leer()
        {
            List<Local> list = new List<Local>();
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM Llamadas WHERE Tipo = 0;";
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Local(
                            (float)Convert.ToDouble(reader["Duracion"]),
                            reader["Destino"].ToString(),
                            reader["Origen"].ToString(),
                            (float)Convert.ToDouble(reader["Costo"])
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