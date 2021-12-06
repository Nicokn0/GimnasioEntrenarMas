using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace Datos
{
    public class Sala
    {
        public static DataTable TraerTodos(string pFiltro)
        {
            DataTable dt = new DataTable();

            string strSQL = @"Select * from salas ORDER BY ID DESC "; // trabajo con str y mysql 

            MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());  //adaptador de mysql y que comando ejecutar 

            objtDataAdapterTraer.Fill(dt); // llena dentro del obj datatable todos los datos que devuela la consulta

            return dt;
        }
     
        public static DataTable TraerTodos()
        {
            DataTable dt = new DataTable();

            string strSQL = "Select * from salas"; // trabajo con str y mysql 

            MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());  //adaptador de mysql y que comando ejecutar 

            objtDataAdapterTraer.Fill(dt); // llena dentro del obj datatable todos los datos que devuela la consulta

            return dt;
        }

        public static void AgregarSala(Entidades.Sala objSala)
        {
        
            MySqlConnection objConexion = new MySqlConnection(Conexion.ConectorMySql());

         
            string sqlString = @"INSERT INTO salas(Id, Nombre)

                               VALUES(@Id, @Nombre)"; // instruccion de arriba debo respetar el orden

       

            MySqlCommand objMySqlCommand = new MySqlCommand(sqlString, objConexion); //vamos a utilizar un constructir . Vamos a pasar el string de la consulta y la conexion de la consulta


            objMySqlCommand.Parameters.AddWithValue("@Id", objSala.Id);
            objMySqlCommand.Parameters.AddWithValue("@Nombre", objSala.Nombre);
          

            objConexion.Open();

            objMySqlCommand.ExecuteNonQuery(); 

            objConexion.Close();// cerrar la conexión

        }

        public static void BorrarSala(int id)
        {

            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());


            string strSQL = @"delete from salas where Id= @Id";


            MySqlCommand objMySqlcommand = new MySqlCommand(strSQL, objconexion);


            objMySqlcommand.Parameters.AddWithValue("@Id", id);



            objconexion.Open();


            objMySqlcommand.ExecuteNonQuery();


            objconexion.Close();

        }

        public static void BorrarSala(string nombre)
            {

                MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());


                string strSQL = @"delete from salas  where "
               + " Nombre like '%" + nombre + "%'";


                MySqlCommand objMySqlcommand = new MySqlCommand(strSQL, objconexion);

                objMySqlcommand.Parameters.AddWithValue("@Nombre", nombre);

                objconexion.Open();

                objMySqlcommand.ExecuteNonQuery();

                objconexion.Close();

            }

        public static void ModificarSala(Entidades.Sala objSala)
        {
            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());

            string sqlString = @"UPDATE salas SET Id= @Id, Nombre= @Nombre


           where Id = @Id";

            MySqlCommand objMySqlcommand = new MySqlCommand(sqlString, objconexion);

            objMySqlcommand.Parameters.AddWithValue("@Id", objSala.Id);
            objMySqlcommand.Parameters.AddWithValue("@Nombre", objSala.Nombre);
          

            objconexion.Open();

            objMySqlcommand.ExecuteNonQuery();

            objconexion.Close();
        }

        public static DataTable BuscarSala (int id)
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from salas where "
           + "Id = " + id;


            try
            {
                MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSql, Conexion.ConectorMySql());

                objtDataAdapterTraer.Fill(dt);

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public static DataTable BuscarSala(int id, string nombre)
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from salas where "
               + " Nombre like '%" + nombre + "%'"
               + " or  Id = " + id;

            try
            {
                MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSql, Conexion.ConectorMySql());

                objtDataAdapterTraer.Fill(dt);

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public static DataTable BuscarSala( string nombre)
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from salas where "
               + " Nombre like '%" + nombre + "%'";
          

            try
            {
                MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSql, Conexion.ConectorMySql());

                objtDataAdapterTraer.Fill(dt);

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

    

    }
}
