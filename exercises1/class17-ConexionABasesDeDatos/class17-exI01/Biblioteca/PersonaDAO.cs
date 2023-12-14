using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public static class PersonaDAO
    {
        static string connectionString;
        static SqlConnection connection;
        static SqlCommand command;
        static PersonaDAO()
        {
            connectionString = "Server=.;Database=tablaPersonas;Trusted_Connection=True;\r\n";
            connection = new SqlConnection(connectionString);
            command = new SqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }
        public static void Guardar(string nombre, string apellido)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = $"INSERT INTO personas (nombre, apellido) VALUES (@nombre, @apellidox);";
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<Persona> Leer()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM personas;";
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personas.Add(new Persona(Convert.ToInt32(reader["id"]), reader["nombre"].ToString(), reader["apellido"].ToString()));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return personas;
        }

        public static Persona LeerPorID(int id)
        {
            Persona persona = null;
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "SELECT * FROM personas WHERE id = @id;";
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        persona = new Persona(Convert.ToInt32(reader["id"]), reader["nombre"].ToString(), reader["apellido"].ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
            return persona;
        }

        public static void Modificar(int id, string nombre, string apellido)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "UPDATE personas SET nombre = @nombre, apellido = @apellido WHERE id = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@apellido", apellido);
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static void Borrar(int id)
        {
            try
            {
                command.Parameters.Clear();
                connection.Open();
                command.CommandText = "DELETE FROM personas WHERE id = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery ();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
