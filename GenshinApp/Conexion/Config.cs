using System;
using MySql.Data.MySqlClient;

namespace GenshinApp.Conexion
{
    public class Config
    {
        private MySqlConnection? con = null;
        private string cadenaConexion;
        private string usuario;
        private string contraseña;

        // Constructor por defecto que inicializa la cadena de conexión
        public Config()
        {
            cadenaConexion = "server=localhost;database=GenshinImpactDB;user=accederInfoGenshin;password=1234;";
        }

        // Constructor personalizado
        public Config(string cadenaConexion, string usuario, string contraseña)
        {
            this.cadenaConexion = cadenaConexion;
            this.usuario = usuario;
            this.contraseña = contraseña;
        }

        // Método para obtener la conexión
        public MySqlConnection GetConexion()
        {
            try
            {
                // Si la conexión no está inicializada o está cerrada, la abre
                if (con == null || con.State == System.Data.ConnectionState.Closed)
                {
                    con = new MySqlConnection(cadenaConexion);
                    con.Open();
                }
            }
            catch (MySqlException ex)
            {
                // Lanza una excepción personalizada si hay un error al conectar
                throw new Exception("Error al conectar con la base de datos: " + ex.Message);
            }

            return con;
        }

        // Método para cerrar la conexión (si está abierta)
        public void CerrarConexion()
        {
            if (con != null && con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }
}
