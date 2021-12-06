using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Logica
{
  public   class Disciplina
    {

        public DataTable TraerTodos(string p)
        {
            return Datos.Disciplina.TraerTodos("");
        }
       
        public static DataTable TraerTodos()
        {
            return Datos.Disciplina.TraerTodos();
        }
        public void AgregarDisciplina(Entidades.Disciplina objDisciplina) //Modificar el Id de la base de datos
        {
            Datos.Disciplina.AgregarDisciplina(objDisciplina);
        }



        public void BorrarDisciplina(int id)
        {
            Datos.Disciplina.BorrarDisciplina(id);
        }

        public void BorrarDisciplina(string nombre)
        {
            Datos.Disciplina.BorrarDisciplina(nombre);
        }

        public void ModificarDisciplina(Entidades.Disciplina objSala)
        {
            Datos.Disciplina.ModificarDisciplina(objSala);
        }

        public DataTable BuscarDisciplina(int id)
        {

            return Datos.Disciplina.BuscarDisciplina(id); // devuelve data TABLEL

        }

        public DataTable BuscarDisciplina(int id, string nombre)
        {

            return Datos.Disciplina.BuscarDisciplina(id, nombre); // devuelve data TABLEL

        }

        public DataTable BuscarDisciplina(string nombre)
        {

            return Datos.Disciplina.BuscarDisciplina(nombre); // devuelve data TABLEL

        }



    }
}
