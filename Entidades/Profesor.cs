using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Profesor
    {
        // Declaro los atributos de los Profesores

        public int Id { get; set; } 

        public string Apellido { get; set; }

        public string Nombre { get; set; }

        public string Sexo { get; set; }

        public string NomFamiliar { get; set; }

        public int Celular { get; set; }

        public int Telefono { get; set; }

        public int TelFamiliar { get; set; }
    }
}
