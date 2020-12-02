using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
   public class Grupos
    {
        [Key]
        public int? IdGrupo { get; set; }
        public int IdGrado { get; set; }
        public int IdInstitucion { get; set; }
    }
}
