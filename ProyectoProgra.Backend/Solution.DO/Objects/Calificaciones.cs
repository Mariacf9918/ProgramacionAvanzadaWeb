using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Calificaciones
    {
        [Key]
        public int? IdCalificacion { get; set; }
        public int IdGrupo { get; set; }
        public int Cedula { get; set; }
        public int IdTipoOperacion { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }
        public decimal Nota { get; set; }
        public DateTime Fecha { get; set; }
    }
}
