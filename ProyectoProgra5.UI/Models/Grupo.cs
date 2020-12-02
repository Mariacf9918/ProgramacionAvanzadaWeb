using System;
using System.Collections.Generic;

#nullable disable

namespace ProyectoProgra5.UI.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            Calificaciones = new HashSet<Calificacione>();
            UsuarioXGrupos = new HashSet<UsuarioXGrupo>();
        }

        public int IdGrupo { get; set; }
        public int IdGrado { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Grado IdGradoNavigation { get; set; }
        public virtual Institucione IdInstitucionNavigation { get; set; }
        public virtual ICollection<Calificacione> Calificaciones { get; set; }
        public virtual ICollection<UsuarioXGrupo> UsuarioXGrupos { get; set; }
    }
}
