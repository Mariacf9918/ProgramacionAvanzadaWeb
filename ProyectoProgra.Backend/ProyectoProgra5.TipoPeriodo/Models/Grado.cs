using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.TipoPeriodo.Models
{
    public partial class Grado
    {
        public Grado()
        {
            Grupos = new HashSet<Grupo>();
        }

        public int IdGrado { get; set; }
        public string Descripcion { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Institucione IdInstitucionNavigation { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
    }
}
