using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Puntajes = new HashSet<Puntajes>();
        }

        public decimal IdAlumno { get; set; }
        public decimal? IdReparticion { get; set; }
        public decimal? IdPersona { get; set; }

        public virtual Personas IdPersonaNavigation { get; set; }
        public virtual Reparticiones IdReparticionNavigation { get; set; }
        public virtual ICollection<Puntajes> Puntajes { get; set; }
    }
}
