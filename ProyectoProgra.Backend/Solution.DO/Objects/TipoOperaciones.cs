using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class TipoOperaciones
    {
        [Key]
        public int? IdTipoOperacion { get; set; }
        public string Descripcion { get; set; }
        public int Porcentaje { get; set; }
        public int IdInstitucion { get; set; }
    }
}
