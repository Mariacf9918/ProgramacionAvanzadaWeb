using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Models
{
    public class Grupos
    {
        public int? IdGrupo { get; set; }
        public int IdGrado { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Grados IdGradoNavigation { get; set; }
        public virtual Instituciones IdInstitucionNavigation { get; set; }
    }
}
