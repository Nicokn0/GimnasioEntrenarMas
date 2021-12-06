using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
    public class Clase
    {

        public DataTable TraerTodos(string p)
        {

            return Datos.Clase.TraerTodos("");
        }

        public void Agregar(Entidades.Clase objClase) // le paso por parametro desde entidad un obj se trabaja desde la base de datos
        {
            Datos.Clase.Agregar(objClase);
        }

        public static void ModificarClase(Entidades.Clase objClase)
        {
            Datos.Clase.ModificarClase(objClase);
        }

        public void BorrarClase(int id)
        {
            Datos.Clase.BorrarClase(id);
        }
        
        public DataTable MostrarClase(string objClase)
        {
          return  Datos.Clase.MostrarClase("");
        }

        public DataTable BuscarClase(int id)
        {

            return Datos.Clase.BuscarClase(id); // devuelve data TABLEL

        }

        public DataTable FiltrarClase(int id)
        {

            return Datos.Clase.FiltrarClase(id); // devuelve data TABLEL

        }
    
        public static DataTable MostrarClasesID()
        {
            return Datos.Clase.MostrarClasesID();
        }
    }
}
