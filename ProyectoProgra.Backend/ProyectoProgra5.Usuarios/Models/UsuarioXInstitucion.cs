using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.Usuarios.Models
{
    public partial class UsuarioXInstitucion
    {
        public int IdUsuarioXinstitucion { get; set; }
        public int Cedula { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Institucione IdInstitucionNavigation { get; set; }
    }
}
