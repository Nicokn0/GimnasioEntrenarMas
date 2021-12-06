using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
  public  class Sala
    {
        public  DataTable TraerTodos(string p)
        {

            return Datos.Sala.TraerTodos("");
        }

        public static DataTable TraerTodos()
        {

            return Datos.Sala.TraerTodos();
        }
   
        public void Agregar(Entidades.Sala objSala) // le paso por parametro desde entidad un obj se trabaja desde la base de datos
        {
            Datos.Sala.AgregarSala(objSala);
        }

        public void BorrarSala(int id)
        {
            Datos.Sala.BorrarSala(id);
        }

        public void BorrarSala(string nombre)
        {
            Datos.Sala.BorrarSala(nombre);
        }
      
        public void ModificarSala(Entidades.Sala objSala)
        {
            Datos.Sala.ModificarSala(objSala);
        }

        public DataTable BuscarSala(int id)
        {

            return Datos.Sala.BuscarSala(id); // devuelve data TABLEL

        }

        public DataTable BuscarSala(int id, string nombre)
        {

            return Datos.Sala.BuscarSala(id, nombre); // devuelve data TABLEL

        }

        public DataTable BuscarSala(string nombre)
        {

            return Datos.Sala.BuscarSala(nombre); // devuelve data TABLEL

        }
    }
}
