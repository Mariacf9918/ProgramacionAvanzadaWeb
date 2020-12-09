using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Models
{
    public class UsuarioXGrupo
    {
        public int? IdUsuarioXgrupo { get; set; }
        public int IdGrupo { get; set; }
        public int Cedula { get; set; }

        public virtual Usuarios CedulaNavigation { get; set; }
        public virtual Grupos IdGrupoNavigation { get; set; }
    }
}
