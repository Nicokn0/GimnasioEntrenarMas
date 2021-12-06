using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
    public class Profesor
    {
        public DataTable TraerTodos(string p)
        {

            return Datos.Profesor.TraerTodos("");
        }

        public void Agregar(Entidades.Profesor objProfesor) // le paso por parametro desde entidad un obj se trabaja desde la base de datos
        {
            Datos.Profesor.Agregar(objProfesor);
        }

        public Entidades.Profesor TraerUno(string paplleido, string pnombre)
        {
            return Datos.Profesor.TraerUno(paplleido, pnombre);

        }

        public void ModificarProfe(Entidades.Profesor objProfe)
        {
            Datos.Profesor.ModificarProfe(objProfe);
        }

        public void BorrarProfesor(string pNombre, string pApellido)
        {
            Datos.Profesor.BorrarProfesor(pNombre, pApellido);
        }
       
        public void BorrarProfesor(int id)
        {
            Datos.Profesor.BorrarProfesor(id);
        }
       
        public DataTable BuscarProfe(string papellido)
        {

            return Datos.Profesor.BuscarProfesor(papellido); // devuelve data TABLEL

        }
       
        public DataTable BuscarProfe(string pnombre, string papellido)
        {

            return Datos.Profesor.BuscarProfesor(papellido); // devuelve data TABLEL

        }
       
        
        public DataTable BuscarProfe(int id, string papellido)
        {

            return Datos.Profesor.BuscarProfesor(id, papellido); // devuelve data TABLEL

        }
        

        public DataTable BuscarProfe(int id)
        {

            return Datos.Profesor.BuscarProfesor(id); // devuelve data TABLEL

        }

        public static DataTable MostrarProfesor()
        {
            return Datos.Profesor.MostrarProfesor();
        }


    }
}
