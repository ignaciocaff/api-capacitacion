using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Reparticiones
    {
        public Reparticiones()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public decimal IdReparticion { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
