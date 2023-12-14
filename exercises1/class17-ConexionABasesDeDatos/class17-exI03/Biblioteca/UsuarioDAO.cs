using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class UsuarioDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        static UsuarioDAO()
        {
            cadenaConexion = "Server=.;Database=EJERCICIOS_UTN;Trusted_Connection=True;\r\n";
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static List<Usuario> Leer()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                conexion.Open();
                comando.CommandText = "SELECT * FROM USUARIOS;";
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        usuarios.Add(new Usuario(
                            Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["USERNAME"].ToString()
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
            return usuarios;
        }
    }
}
