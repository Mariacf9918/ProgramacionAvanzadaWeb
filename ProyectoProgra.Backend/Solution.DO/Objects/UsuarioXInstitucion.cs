using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
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
