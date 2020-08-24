using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Profesores
    {
        public Profesores()
        {
            Puntajes = new HashSet<Puntajes>();
        }

        public decimal IdProfesor { get; set; }
        public decimal? IdCargo { get; set; }
        public decimal? IdPersona { get; set; }

        public virtual Cargos IdCargoNavigation { get; set; }
        public virtual Personas IdPersonaNavigation { get; set; }
        public virtual ICollection<Puntajes> Puntajes { get; set; }
    }
}
