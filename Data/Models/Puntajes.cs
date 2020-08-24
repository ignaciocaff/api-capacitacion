using System;
using System.Collections.Generic;

namespace Data.Models
{
    public partial class Puntajes
    {
        public decimal IdPuntaje { get; set; }
        public decimal IdTema { get; set; }
        public decimal IdProfesor { get; set; }
        public decimal? Interes { get; set; }
        public decimal? Complejidad { get; set; }
        public decimal? Entendimiento { get; set; }
        public decimal? Valoracion { get; set; }
        public string Observaciones { get; set; }
        public decimal IdAlumno { get; set; }

        public virtual Alumnos IdAlumnoNavigation { get; set; }
        public virtual Profesores IdProfesorNavigation { get; set; }
        public virtual Temas IdTemaNavigation { get; set; }
    }
}
