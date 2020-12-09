using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Models
{
    public class TipoOperaciones
    {
        public int? IdTipoOperacion { get; set; }
        public string Descripcion { get; set; }
        public int Porcentaje { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
    }
}
