using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class UsuarioXGrupo
    {
        [Key]
        public int? IdUsuarioXgrupo { get; set; }
        public int IdGrupo { get; set; }
        public int Cedula { get; set; }
    }
}
