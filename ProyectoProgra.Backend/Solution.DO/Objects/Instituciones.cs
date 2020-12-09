using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Instituciones
    {
        public Instituciones()
        {
            Grados = new HashSet<Grados>();
            Grupos = new HashSet<Grupos>();
            Materia = new HashSet<Materias>();
            TipoOperaciones = new HashSet<TipoOperaciones>();
            TipoPeriodos = new HashSet<TipoPeriodo>();
            UsuarioXInstitucions = new HashSet<UsuarioXInstitucion>();
        }

        public int? IdInstitucion { get; set; }
        public string NombreInstitucion { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Encargado { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        public virtual ICollection<Grados> Grados { get; set; }
        public virtual ICollection<Grupos> Grupos { get; set; }
        public virtual ICollection<Materias> Materia { get; set; }
        public virtual ICollection<TipoOperaciones> TipoOperaciones { get; set; }
        public virtual ICollection<TipoPeriodo> TipoPeriodos { get; set; }
        public virtual ICollection<UsuarioXInstitucion> UsuarioXInstitucions { get; set; }
    }
}
