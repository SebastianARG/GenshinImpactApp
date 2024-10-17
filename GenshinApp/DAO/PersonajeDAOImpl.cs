using GenshinApp.Conexion;
using GenshinApp.Logica;
using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace GenshinApp.DAO
{
    internal class PersonajeDAOImpl : PersonajeDAO
    {
        Config config;

        // Constructor para recibir la configuración de conexión
        public PersonajeDAOImpl(Config config)
        {
            this.config = config;
        }

        // Método para mostrar todos los personajes
        public List<Personaje> mostrarPersonajes()
        {
            List<Personaje> personajes = new List<Personaje>();

            try
            {
                using (MySqlConnection connection = config.GetConexion()) // Usamos la conexión de Config
                {
                    string query = "SELECT * FROM Personajes";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Personaje personaje = new Personaje
                        {
                            Id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            elemento = reader.GetString(2),
                            arma = reader.GetString(3),
                            Estrellas = reader.GetInt32(4),
                            Region = reader.GetString(5)
                        };
                        personajes.Add(personaje);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PersonajeDAOException("Error al mostrar los personajes: " + ex.Message);
            }

            return personajes;
        }

        public List<Personaje> mostrarPersonajesPorRegion(string region)
        {
            List<Personaje> personajes = new List<Personaje>();

            try
            {
                using (MySqlConnection connection = config.GetConexion()) // Usamos la conexión de Config
                {
                    string query = "SELECT * FROM Personajes WHERE Region = @Region";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Region", region);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Personaje personaje = new Personaje
                        {
                            Id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            elemento = reader.GetString(2),
                            arma = reader.GetString(3),
                            Estrellas = reader.GetInt32(4),
                            Region = reader.GetString(5)
                        };
                        personajes.Add(personaje);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PersonajeDAOException("Error al mostrar los personajes: " + ex.Message);
            }

            return personajes;
        }

        // Método para mostrar un personaje por su ID
        public Personaje mostrarPersonaje(int id)
        {
            Personaje personaje = null;

            try
            {
                using (MySqlConnection connection = config.GetConexion()) // Usamos la conexión de Config
                {
                    string query = "SELECT * FROM Personajes WHERE Id = @Id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        personaje = new Personaje
                        {
                            Id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            elemento = reader.GetString(2),
                            arma = reader.GetString(3),
                            Estrellas = reader.GetInt32(4),
                            Region = reader.GetString(5)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PersonajeDAOException("Error al mostrar el personaje con ID " + id + ": " + ex.Message);
            }

            return personaje;
        }

        public Personaje obtenerPersonajePorNombre(string nombre)
        {
            Personaje personaje = null;

            try
            {
                using (MySqlConnection connection = config.GetConexion()) // Usamos la conexión de Config
                {
                    string query = "SELECT * FROM Personajes WHERE Nombre = @Nombre";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        personaje = new Personaje
                        {
                            Id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            elemento = reader.GetString(2),
                            arma = reader.GetString(3),
                            Estrellas = reader.GetInt32(4),
                            Region = reader.GetString(5)
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                throw new PersonajeDAOException("Error al mostrar el personaje con nombre " + nombre + ": " + ex.Message);
            }
            

            return personaje;
        }

        // Método para verificar si un personaje existe por su nombre
        public bool existePersonaje(string nombre)
        {
            bool existe = false;

            try
            {
                using (MySqlConnection connection = config.GetConexion()) // Usamos la conexión de Config
                {
                    string query = "SELECT COUNT(1) FROM Personajes WHERE Nombre = @Nombre";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", nombre);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    existe = count > 0;
                }
            }
            catch (Exception ex)
            {
                throw new PersonajeDAOException("Error al verificar si existe el personaje " + nombre + ": " + ex.Message);
            }
            return existe;
        }
    }
}
