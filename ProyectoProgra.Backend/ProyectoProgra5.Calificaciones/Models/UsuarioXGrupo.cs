using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.Calificaciones.Models
{
    public partial class UsuarioXGrupo
    {
        public int IdUsuarioXgrupo { get; set; }
        public int IdGrupo { get; set; }
        public int Cedula { get; set; }

        public virtual Usuario CedulaNavigation { get; set; }
        public virtual Grupo IdGrupoNavigation { get; set; }
    }
}
