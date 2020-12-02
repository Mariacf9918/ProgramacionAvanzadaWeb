using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.Instituciones.Models
{
    public partial class Institucione
    {
        public Institucione()
        {
            Grados = new HashSet<Grado>();
            Grupos = new HashSet<Grupo>();
            Materia = new HashSet<Materia>();
            TipoOperaciones = new HashSet<TipoOperacione>();
            TipoPeriodos = new HashSet<TipoPeriodo>();
            UsuarioXInstitucions = new HashSet<UsuarioXInstitucion>();
        }

        public int IdInstitucion { get; set; }
        public string NombreInstitucion { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Encargado { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }

        public virtual ICollection<Grado> Grados { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Materia> Materia { get; set; }
        public virtual ICollection<TipoOperacione> TipoOperaciones { get; set; }
        public virtual ICollection<TipoPeriodo> TipoPeriodos { get; set; }
        public virtual ICollection<UsuarioXInstitucion> UsuarioXInstitucions { get; set; }
    }
}
