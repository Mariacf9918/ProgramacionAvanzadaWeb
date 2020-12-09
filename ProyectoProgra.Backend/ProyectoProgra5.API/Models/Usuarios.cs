using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Models
{
    public class Usuarios
    {
        public int? Cedula { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public int Telefono { get; set; }
        public int IdRol { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        //public virtual ICollection<Calificaciones> Calificaciones { get; set; }
        //public virtual ICollection<UsuarioXGrupo> UsuarioXGrupos { get; set; }
       // public virtual ICollection<UsuarioXInstitucion> UsuarioXInstitucions { get; set; }
    }
}
