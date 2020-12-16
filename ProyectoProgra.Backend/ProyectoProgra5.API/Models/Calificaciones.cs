using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Models
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

        public virtual Usuarios CedulaNavigation { get; set; }
        public virtual Grupos IdGrupoNavigation { get; set; }
        public virtual Materias IdMateriaNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
        public virtual TipoOperaciones IdTipoOperacionNavigation { get; set; }
    }
}
