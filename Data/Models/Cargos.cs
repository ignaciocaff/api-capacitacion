using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Cargos
    {
        public Cargos()
        {
            Profesores = new HashSet<Profesores>();
        }

        public decimal IdCargo { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Profesores> Profesores { get; set; }
    }
}
