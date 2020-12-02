using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.UI.Models
{
    public partial class TipoPeriodo
    {
        public TipoPeriodo()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public int IdPeriodo { get; set; }
        public string Descripcion { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Institucione IdInstitucionNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
