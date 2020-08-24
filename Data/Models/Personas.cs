using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Personas
    {
        public Personas()
        {
            Alumnos = new HashSet<Alumnos>();
            Profesores = new HashSet<Profesores>();
        }

        public decimal IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal? Edad { get; set; }
        public string Cuil { get; set; }

        public virtual ICollection<Alumnos> Alumnos { get; set; }
        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
