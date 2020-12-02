using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class UsuarioXInstitucion
    {
        [Key]
        public int? IdUsuarioXInstitucion { get; set; }
        public int Cedula { get; set; }
        public int IdInstitucion { get; set; }
    }
}
