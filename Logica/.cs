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

            return Datos.Sala.TraerTodos("");
        }

        public void Agregar(Entidades.Sala objSala) // le paso por parametro desde entidad un obj se trabaja desde la base de datos
        {
            Datos.Sala.AgregarSala(objSala);
        }

        public void BorrarProfesor(int id)
        {
            Datos.Sala.BorrarSala(id);
        }

        public void ModificarSala(Entidades.Sala objSala)
        {
            Datos.Sala.ModificarSala(objSala);
        }

        public DataTable BuscarSala(int id)
        {

            return Datos.Sala.BuscarSala(id); // devuelve data TABLEL

        }
    }
}
