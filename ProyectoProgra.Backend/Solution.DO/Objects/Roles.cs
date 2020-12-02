using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Roles
    {
        [Key]
        public int? IdRol { get; set; }
        public string Descripcion { get; set; }
    }
}
