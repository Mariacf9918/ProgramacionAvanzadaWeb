using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Usuarios
    {
      
        public Usuarios()
        {
            Calificaciones = new HashSet<Calificaciones>();
            UsuarioXGrupos = new HashSet<UsuarioXGrupo>();
            UsuarioXInstitucions = new HashSet<UsuarioXInstitucion>();
        }

        public int? Cedula { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public int Telefono { get; set; }
        public int IdRol { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
        public virtual ICollection<UsuarioXGrupo> UsuarioXGrupos { get; set; }
        public virtual ICollection<UsuarioXInstitucion> UsuarioXInstitucions { get; set; }

    }
}
