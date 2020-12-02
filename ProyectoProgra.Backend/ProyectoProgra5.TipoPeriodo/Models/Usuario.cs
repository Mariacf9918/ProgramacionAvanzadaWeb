using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.TipoPeriodo.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Calificaciones = new HashSet<Calificacione>();
            UsuarioXGrupos = new HashSet<UsuarioXGrupo>();
            UsuarioXInstitucions = new HashSet<UsuarioXInstitucion>();
        }

        public int Cedula { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public int Telefono { get; set; }
        public int IdRol { get; set; }

        public virtual Role IdRolNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<UsuarioXGrupo> UsuarioXGrupos { get; set; }
        public virtual ICollection<UsuarioXInstitucion> UsuarioXInstitucions { get; set; }
    }
}
