using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class JuegoDAO
    {
        static string cadenaConexion;
        static SqlCommand comando;
        static SqlConnection conexion;

        static JuegoDAO()
        {
            cadenaConexion = "Server=.;Database=EJERCICIOS_UTN;Trusted_Connection=True;\r\n";
            conexion = new SqlConnection(cadenaConexion);
            comando = new SqlCommand();
            comando.CommandType = System.Data.CommandType.Text;
            comando.Connection = conexion;
        }

        public static void Eliminar(int codigoJuego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "DELETE FROM JUEGOS WHERE CODIGO_JUEGO = @codigoJuego;";
                comando.Parameters.AddWithValue("@codigoJuego", codigoJuego);
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

        public static void Guardar(Juego juego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "" +
                    "INSERT INTO JUEGOS (CODIGO_USUARIO, NOMBRE, PRECIO, GENERO) " +
                    "VALUES (@codigoUsuario, @nombre, @precio, @genero);";
                comando.Parameters.AddWithValue("@codigoUsuario", juego.CodigoUsuario);
                comando.Parameters.AddWithValue("@nombre", juego.Nombre);
                comando.Parameters.AddWithValue("@precio", juego.Precio);
                comando.Parameters.AddWithValue("@genero", juego.Genero);
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

        public static List<Biblioteca> Leer()
        {
            List<Biblioteca> bibliotecas = new List<Biblioteca>();
            try
            {
                conexion.Open();
                comando.CommandText = "" +
                    "SELECT * " +
                    "FROM JUEGOS " +
                    "INNER JOIN USUARIOS " +
                    "ON JUEGOS.CODIGO_USUARIO = USUARIOS.CODIGO_USUARIO;";
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bibliotecas.Add(new Biblioteca(
                            Convert.ToInt32(reader["CODIGO_JUEGO"]),
                            reader["GENERO"].ToString(),
                            reader["NOMBRE"].ToString(),
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
            return bibliotecas;
        }

        public static Juego LeerPorId(int codigoJuego)
        {
            Juego juego = null;
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "" +
                    "SELECT * " +
                    "FROM JUEGOS " +
                    "WHERE CODIGO_JUEGO = @codigoJuego;";
                comando.Parameters.AddWithValue("@codigoJuego", codigoJuego);
                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        juego = new Juego(
                            Convert.ToInt32(reader["CODIGO_JUEGO"]),
                            Convert.ToInt32(reader["CODIGO_USUARIO"]),
                            reader["GENERO"].ToString(),
                            reader["NOMBRE"].ToString(),
                            Convert.ToDouble(reader["PRECIO"])
                            );
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
            return juego;
        }

        public static void Modificar(Juego juego)
        {
            try
            {
                comando.Parameters.Clear();
                conexion.Open();
                comando.CommandText = "" +
                    "UPDATE JUEGOS " +
                    "SET CODIGO_USUARIO = @codigoUsuario, NOMBRE = @nombre, PRECIO = @precio, GENERO = @genero " +
                    "WHERE CODIGO_JUEGO = @codigoJuego;";
                comando.Parameters.AddWithValue("@codigoUsuario", juego.CodigoUsuario);
                comando.Parameters.AddWithValue("@nombre", juego.Nombre);
                comando.Parameters.AddWithValue("@precio", juego.Precio);
                comando.Parameters.AddWithValue("@genero", juego.Genero);
                comando.Parameters.AddWithValue("@codigoJuego", juego.CodigoJuego);
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
    }
}
