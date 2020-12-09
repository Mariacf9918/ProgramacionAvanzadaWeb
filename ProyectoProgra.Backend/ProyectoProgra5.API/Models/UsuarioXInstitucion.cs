using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Models
{
    public class UsuarioXInstitucion
    {
        public int? IdUsuarioXInstitucion { get; set; }
        public int Cedula { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Usuarios CedulaNavigation { get; set; }
        public virtual Instituciones IdInstitucionNavigation { get; set; }
    }
}
