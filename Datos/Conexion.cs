using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Datos
{
    public static  class Conexion
    {

        internal static string strConexion = ""; // Para creaar una conexion que sea referenciada por cualquier obj en cualquier momento 

        public static String ConectorMySql()
        {
            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();

            connBuilder.Add("Data Source", "localHost"); // servidor - puerto 1 ° nviel de autenticacion
            connBuilder.Add("Port", "3306");
            connBuilder.Add("Database", "gimnasioentrenarmas");
            connBuilder.Add("User Id", "root"); // usuario
                                                // connBuilder.Add("Password", "");


            MySqlConnection connection = new MySqlConnection(connBuilder.ConnectionString);

            strConexion = connBuilder.ConnectionString;

            return strConexion;

            // MANERA DE CONECTARME A LA BASE DE DATOS lo de arriba es el conexion string 
        }

    }
}
