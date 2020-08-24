using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Temas
    {
        public Temas()
        {
            Puntajes = new HashSet<Puntajes>();
        }

        public decimal IdTema { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Duracion { get; set; }

        public virtual ICollection<Puntajes> Puntajes { get; set; }
    }
}
