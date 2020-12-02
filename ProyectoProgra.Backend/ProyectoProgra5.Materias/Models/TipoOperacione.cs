using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.Materias.Models
{
    public partial class TipoOperacione
    {
        public TipoOperacione()
        {
            Calificaciones = new HashSet<Calificacione>();
        }

        public int IdTipoOperacion { get; set; }
        public string Descripcion { get; set; }
        public int Porcentaje { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Institucione IdInstitucionNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
    }
}
