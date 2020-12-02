using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.UsuarioXInstitucion.Models
{
    public partial class Materia
    {
        public Materia()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public int IdMateria { get; set; }
        public string Descripcion { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Institucione IdInstitucionNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
