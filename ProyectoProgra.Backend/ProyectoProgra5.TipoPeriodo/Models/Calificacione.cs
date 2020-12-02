using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.TipoPeriodo.Models
{
    public partial class Calificacione
    {
        public int IdCalificacion { get; set; }
        public int IdGrupo { get; set; }
        public int Cedula { get; set; }
        public int IdTipoOperacion { get; set; }
        public int IdMateria { get; set; }
        public int IdPeriodo { get; set; }
        public decimal Nota { get; set; }
        public DateTime Fecha { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Grupo IdGrupoNavigation { get; set; }
        public virtual Materia IdMateriaNavigation { get; set; }
        public virtual TipoPeriodo IdPeriodoNavigation { get; set; }
        public virtual TipoOperacione IdTipoOperacionNavigation { get; set; }
    }
}
