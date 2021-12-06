using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySqlConnector;

namespace Datos
{
    //Si lego repasar traer tdoodos

    public class Disciplina
    {
        public static DataTable TraerTodos(string pFiltro)
        {
            DataTable dt = new DataTable();

            string strSQL = @"Select * from disciplinas ORDER BY ID DESC"; // trabajo con str y mysql 

            MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());  //adaptador de mysql y que comando ejecutar 

            objtDataAdapterTraer.Fill(dt); // llena dentro del obj datatable todos los datos que devuela la consulta

            return dt;
        }

        public static DataTable TraerTodos()
        {
            DataTable dt = new DataTable();

            string strSQL = "select ID, Nombre from disciplinas";

            MySqlDataAdapter objDataAdapterTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());

            objDataAdapterTraer.Fill(dt);

            return dt;
        }

        public static void AgregarDisciplina(Entidades.Disciplina objDisciplina)
        {

            MySqlConnection objConexion = new MySqlConnection(Conexion.ConectorMySql());


            string sqlString = @"INSERT INTO disciplinas(Id, Nombre, Descripcion)

                               VALUES(@Id, @Nombre, @Descripcion)"; // instruccion de arriba debo respetar el orden

          
            MySqlCommand objMySqlCommand = new MySqlCommand(sqlString, objConexion); //vamos a utilizar un constructir . Vamos a pasar el string de la consulta y la conexion de la consulta


            objMySqlCommand.Parameters.AddWithValue("@Id", objDisciplina.Id);
            objMySqlCommand.Parameters.AddWithValue("@Nombre", objDisciplina.Nombre);
            objMySqlCommand.Parameters.AddWithValue("@Descripcion", objDisciplina.Descripcion);


            objConexion.Open();

            objMySqlCommand.ExecuteNonQuery();

            objConexion.Close();// cerrar la conexión

        }

        public static void BorrarDisciplina(int id) //Listo
        {

            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());


            string strSQL = @"delete from disciplinas where Id= @Id";


            MySqlCommand objMySqlcommand = new MySqlCommand(strSQL, objconexion);


            objMySqlcommand.Parameters.AddWithValue("@Id", id);



            objconexion.Open();


            objMySqlcommand.ExecuteNonQuery();


            objconexion.Close();

        }

        public static void BorrarDisciplina(string nombre) //Listo
        {

            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());


            string strSQL = @"delete from disciplinas  where "
           + " Nombre like '%" + nombre + "%'";


            MySqlCommand objMySqlcommand = new MySqlCommand(strSQL, objconexion);

            objMySqlcommand.Parameters.AddWithValue("@Nombre", nombre);

            objconexion.Open();

            objMySqlcommand.ExecuteNonQuery();

            objconexion.Close();

        }

        public static void ModificarDisciplina(Entidades.Disciplina objDisciplina) //Listo
        {
            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());

            string sqlString = @"UPDATE disciplinas SET Id= @Id, Nombre= @Nombre, Descripcion= @Descripcion 


           where Id = @Id";

            MySqlCommand objMySqlcommand = new MySqlCommand(sqlString, objconexion);

            objMySqlcommand.Parameters.AddWithValue("@Id", objDisciplina.Id);
            objMySqlcommand.Parameters.AddWithValue("@Nombre", objDisciplina.Nombre);
            objMySqlcommand.Parameters.AddWithValue("@Descripcion", objDisciplina.Descripcion);


            objconexion.Open();

            objMySqlcommand.ExecuteNonQuery();

            objconexion.Close();
        }

        public static DataTable BuscarDisciplina(int id) //Listo
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from disciplinas where "
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

        public static DataTable BuscarDisciplina(int id, string nombre)
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from disciplinas where "
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

        public static DataTable BuscarDisciplina(string nombre)
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from disciplinas where "
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
