using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class TipoOperaciones
    {
        public TipoOperaciones()
        {
            Calificaciones = new HashSet<Calificaciones>();
        }

        public int? IdTipoOperacion { get; set; }
        public string Descripcion { get; set; }
        public int Porcentaje { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
    }
}
