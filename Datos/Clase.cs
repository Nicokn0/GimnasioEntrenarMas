using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;


namespace Datos
{
   public  class Clase
    {

        public static DataTable TraerTodos(string pFiltro)
        {
            DataTable dt = new DataTable();

            string strSQL = "Select * from clases ORDER BY ID DESC"; // trabajo con str y mysql 

            MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());  //adaptador de mysql y que comando ejecutar 

            objtDataAdapterTraer.Fill(dt); // llena dentro del obj datatable todos los datos que devuela la consulta

            return dt;
        }

        public static void Agregar(Entidades.Clase objClase) 
        {
            // SQL CONNECTION .vamos agregar un autor
            // necesitamos un conecctor string 
            // vamos a neecesitar un obj comand que ejecuta una accion en la base de datos INSTRUCCION  INSERT // UPDTAE // DELETE
            // Eventualmente si nuestro comando requiere parametros agregarselos al comando para que los considere al momento de ejecutar

            MySqlConnection objConexion = new MySqlConnection(Conexion.ConectorMySql());

            // Sentencia sql que voy  a ejecutar 
            string sqlString = @"INSERT INTO clases(Id, Profesor, Disciplina, Sala, Duracion)

                               VALUES(@Id, @Profesor, @Disciplina, @Sala, @Duracion)";

            // CREAMOS EL OBJ QUE PERMITIRA EJECUTAR LA CONSULTA 

            MySqlCommand objMySqlCommand = new MySqlCommand(sqlString, objConexion); //vamos a utilizar un constructir . Vamos a pasar el string de la consulta y la conexion de la consulta

            // agregamos los paramtetros  necesarios  para comand

            objMySqlCommand.Parameters.AddWithValue("@Id", objClase.Id);
            objMySqlCommand.Parameters.AddWithValue("@Profesor", objClase.Profesor);
            objMySqlCommand.Parameters.AddWithValue("@Disciplina", objClase.Disciplina);
            objMySqlCommand.Parameters.AddWithValue("@Sala", objClase.Sala);
            objMySqlCommand.Parameters.AddWithValue("@Duracion", objClase.Duracion);
         


            // VAMOS ABRIR LA CONEXION con la base de datos

            // VAMOS ABRIR LA CONEXION con la base de datos

            objConexion.Open();

            objMySqlCommand.ExecuteNonQuery(); // ejecuta la consulta  con los parametros ya pasados y remplazados por lo qye viene del obj y no espero que devuelva nada solo ejecuta la consulta 

            // devuelve 1 o 0 si el insert to tiene otra agregación puede dar otro numero 

            objConexion.Close();// cerrar la conexión

        }
       
        public static void BorrarClase(int Id)
        {

            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());


            string strSQL = @"delete from clases where Id= @Id";


            MySqlCommand objMySqlcommand = new MySqlCommand(strSQL, objconexion);


            objMySqlcommand.Parameters.AddWithValue("@Id", Id);

            objconexion.Open();


            objMySqlcommand.ExecuteNonQuery();


            objconexion.Close();

        }
        
        public static void ModificarClase(Entidades.Clase objclase)
        {
            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());

            string sqlString = @"UPDATE clases SET  Profesor = @Profesor, 
            Disciplina= @Disciplina, Sala= @Sala, Duracion = @Duracion

           where Id = @Id";
           
            MySqlCommand objMySqlcommand = new MySqlCommand(sqlString, objconexion);

            objMySqlcommand.Parameters.AddWithValue("@Id", objclase.Id);
            objMySqlcommand.Parameters.AddWithValue("@Profesor", objclase.Profesor);
            objMySqlcommand.Parameters.AddWithValue("@Disciplina", objclase.Disciplina);
            objMySqlcommand.Parameters.AddWithValue("@Sala", objclase.Sala);
            objMySqlcommand.Parameters.AddWithValue("@Duracion", objclase.Duracion);
            

            objconexion.Open();

            objMySqlcommand.ExecuteNonQuery();

            objconexion.Close();
        }

        public static DataTable BuscarClase(int id)
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from clases where "
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

       
        public static DataTable MostrarClase (string pfiltro )
        {
            DataTable dt = new DataTable();

            string strSql = @"SELECT cl.Id , concat_ws(' ', p.Nombre, p.Apellido) AS 'Nombre y Apellido PROFESOR', ds.Nombre  AS 'Disciplina', sl.Nombre AS 'Sala',

            cl.Duracion FROM clases AS cl  INNER JOIN 

            profesores AS p ON  cl.Profesor = p.Id INNER JOIN 

            disciplinas AS ds ON cl.Disciplina = ds.Id  INNER JOIN

            salas AS sl ON  cl.Sala = sl.Id ORDER BY ID DESC";

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

        public static DataTable FiltrarClase(int id)
        {
            DataTable dt = new DataTable();

            string strSql = @"SELECT cl.Id , concat_ws(' ', p.Nombre, p.Apellido) AS 'Nombre y Apellido PROFESOR', ds.Nombre  AS 'Disciplina', sl.Nombre AS 'Sala', cl.Duracion

            FROM clases AS cl  INNER JOIN 

            profesores AS p ON  cl.Profesor = p.Id INNER JOIN 

            disciplinas AS ds ON cl.Disciplina = ds.Id  INNER JOIN

            salas AS sl ON  cl.Sala = sl.Id  where cl.Id =" + id ;

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

        public static DataTable MostrarClasesID()
        {
            //Creamos data table
            DataTable dt = new DataTable();

            //Realizamos la consulta
            string strSQL = "SELECT p.ID AS 'IDPROF', ds.ID AS 'IDDIS' ,sl.ID AS 'IDSAL', cl.Id , concat_ws(' ', p.Nombre, p.Apellido) AS 'PROFESOR', ds.Nombre  AS 'Disciplina', sl.Nombre AS 'Sala', cl.Duracion FROM clases AS cl  INNER JOIN profesores AS p ON  cl.Profesor = p.Id INNER JOIN disciplinas AS ds ON cl.Disciplina = ds.Id INNER JOIN salas AS sl ON cl.Sala = sl.Id ORDER BY cl.Id desc";

            MySqlDataAdapter objDataTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());

            objDataTraer.Fill(dt);

            return dt;
        }

    }
}
