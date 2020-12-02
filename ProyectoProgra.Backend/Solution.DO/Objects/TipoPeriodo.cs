using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class TipoPeriodo
    {
        [Key]
        public int? IdPeriodo { get; set; }
        public string Descripcion { get; set; }
        public int IdInstitucion { get; set; }
    }
}
