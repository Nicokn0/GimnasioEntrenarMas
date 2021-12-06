using MySqlConnector;
using System;
using System.Data;

namespace Datos
{
    public static class Profesor
    {
        public static DataTable TraerTodos(string pFiltro)
        {
            DataTable dt = new DataTable();

            string strSQL = @"Select * from profesores ORDER BY ID DESC"; // trabajo con str y mysql 

            MySqlDataAdapter objtDataAdapterTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());  //adaptador de mysql y que comando ejecutar 

            objtDataAdapterTraer.Fill(dt); // llena dentro del obj datatable todos los datos que devuela la consulta

            return dt;
        }

        public static Entidades.Profesor TraerUno(string pApellido, string pNombre)
        {
            Entidades.Profesor objProfesor = new Entidades.Profesor();

            MySqlConnection objConexion = new MySqlConnection(Conexion.ConectorMySql());

            string strMySQL = @"select * from  profesores where "
                            + " Apellido like '%" + pApellido + "%'"
                            + " or Nombre  like '%" + pNombre + "%'";

            MySqlCommand objTraerAutor = new MySqlCommand(strMySQL, objConexion);

            objTraerAutor.Parameters.AddWithValue("@Apellido", pApellido);
            objTraerAutor.Parameters.AddWithValue("@Nombre", pNombre);
            MySqlDataReader bAutor;

            objConexion.Open();

            bAutor = objTraerAutor.ExecuteReader();

            if (bAutor.Read())
            {

                objProfesor.Apellido = bAutor["Apellido"].ToString();
                objProfesor.Nombre = bAutor["Nombre"].ToString();
                objProfesor.Telefono = int.Parse(bAutor["Telefono"].ToString());
                objProfesor.Celular = int.Parse(bAutor["Celular"].ToString());
                objProfesor.TelFamiliar = int.Parse(bAutor["TelFamiliar"].ToString());
                objProfesor.NomFamiliar = bAutor["NomFamiliar"].ToString();
                objProfesor.Sexo = bAutor["Sexo"].ToString();

            }

            bAutor.Close();

            objConexion.Close();

            return objProfesor;


        }

        public static void Agregar(Entidades.Profesor objProfe)
        {
            // SQL CONNECTION .vamos agregar un autor
            // necesitamos un conecctor string 
            // vamos a neecesitar un obj comand que ejecuta una accion en la base de datos INSTRUCCION  INSERT // UPDTAE // DELETE
            // Eventualmente si nuestro comando requiere parametros agregarselos al comando para que los considere al momento de ejecutar

            MySqlConnection objConexion = new MySqlConnection(Conexion.ConectorMySql());

            // Sentencia sql que voy  a ejecutar 
            string sqlString = @"INSERT INTO profesores(Apellido, Nombre, Sexo, Telefono, Celular, TelFamiliar, NomFamiliar)

                               VALUES(@apellido, @nombre, @sexo, @telefono, @celular, @telFamiliar, @nomFamiliar)"; // instruccion de arriba debo respetar el orden

            // CREAMOS EL OBJ QUE PERMITIRA EJECUTAR LA CONSULTA 

            MySqlCommand objMySqlCommand = new MySqlCommand(sqlString, objConexion); //vamos a utilizar un constructir . Vamos a pasar el string de la consulta y la conexion de la consulta

            // agregamos los paramtetros  necesarios  para comand

            objMySqlCommand.Parameters.AddWithValue("@apellido", objProfe.Apellido);
            objMySqlCommand.Parameters.AddWithValue("@nombre", objProfe.Nombre);
            objMySqlCommand.Parameters.AddWithValue("@sexo", objProfe.Sexo);
            objMySqlCommand.Parameters.AddWithValue("@telefono", objProfe.Telefono);
            objMySqlCommand.Parameters.AddWithValue("@celular", objProfe.Celular);
            objMySqlCommand.Parameters.AddWithValue("@telfamiliar", objProfe.TelFamiliar);
            objMySqlCommand.Parameters.AddWithValue("@nomFamiliar", objProfe.NomFamiliar);


            // VAMOS ABRIR LA CONEXION con la base de datos

            // VAMOS ABRIR LA CONEXION con la base de datos

            objConexion.Open();

            objMySqlCommand.ExecuteNonQuery(); // ejecuta la consulta  con los parametros ya pasados y remplazados por lo qye viene del obj y no espero que devuelva nada solo ejecuta la consulta 

            // devuelve 1 o 0 si el insert to tiene otra agregación puede dar otro numero 

            objConexion.Close();// cerrar la conexión

        }

        public static DataTable BuscarProfesor(string pApellido)
        {
            //buscar x apell. Conjunto de resultados
            DataTable dt = new DataTable();

            string strSql = "select * from profesores  where "
           + " Apellido like '%" + pApellido + "%'  ORDER BY ID DESC";


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

        
        public static DataTable BuscarProfesor(int id, string pApellido)
        {
            //buscar x nom y apell. Conjunto de resultados
            DataTable dt = new DataTable();

            string strSql = @"select * from profesores where "
           + " Apellido like '%" + pApellido + "%'"
           + " and  Id = " + id;


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
        
        public static DataTable BuscarProfesor(int id)
        {

            DataTable dt = new DataTable();

            string strSql = @"select * from profesores where "
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

        public static void ModificarProfe(Entidades.Profesor objProfe)
        {
            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());

            string sqlString = @"UPDATE profesores SET Nombre= @Nombre, Apellido= @Apellido, 
            Sexo= @Sexo, Telefono= @Telefono, Celular = @Celular, TelFamiliar= @TelFamiliar,
            NomFamiliar = @NomFamiliar 
            where Id = @Id";

            MySqlCommand objMySqlcommand = new MySqlCommand(sqlString, objconexion);

            objMySqlcommand.Parameters.AddWithValue("@Id", objProfe.Id);
            objMySqlcommand.Parameters.AddWithValue("@Nombre", objProfe.Nombre);
            objMySqlcommand.Parameters.AddWithValue("@Apellido", objProfe.Apellido);
            objMySqlcommand.Parameters.AddWithValue("@Sexo", objProfe.Sexo);
            objMySqlcommand.Parameters.AddWithValue("@Telefono", objProfe.Telefono);
            objMySqlcommand.Parameters.AddWithValue("@Celular", objProfe.Celular);
            objMySqlcommand.Parameters.AddWithValue("@TelFamiliar", objProfe.TelFamiliar);
            objMySqlcommand.Parameters.AddWithValue("@NomFamiliar", objProfe.NomFamiliar);

            objconexion.Open();

            objMySqlcommand.ExecuteNonQuery();

            objconexion.Close();
        }

        public static void BorrarProfesor(string nombre, string apellido)
        {

            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());


            string strSQL = @"delete from profesores  where "
           + " Apellido like '%" + apellido + "%'"
           + " and Nombre  like '%" + nombre + "%'";


            MySqlCommand objMySqlcommand = new MySqlCommand(strSQL, objconexion);


            objMySqlcommand.Parameters.AddWithValue("@Apellido", apellido);
            objMySqlcommand.Parameters.AddWithValue("@Nombre", nombre);


            objconexion.Open();


            objMySqlcommand.ExecuteNonQuery();


            objconexion.Close();

        }

        public static void BorrarProfesor(int id)
        {

            MySqlConnection objconexion = new MySqlConnection(Conexion.ConectorMySql());


            string strSQL = @"delete from profesores where Id= @Id";


            MySqlCommand objMySqlcommand = new MySqlCommand(strSQL, objconexion);


            objMySqlcommand.Parameters.AddWithValue("@Id", id);



            objconexion.Open();


            objMySqlcommand.ExecuteNonQuery();


            objconexion.Close();

        }

        public static DataTable MostrarProfesor()
        {

            DataTable dt = new DataTable();


            string strSQL = "select ID, CONCAT(Nombre, ' ', Apellido) As Profesor from profesores";

            MySqlDataAdapter objDataTraer = new MySqlDataAdapter(strSQL, Conexion.ConectorMySql());

            objDataTraer.Fill(dt);

            return dt;
        }
    }
}
