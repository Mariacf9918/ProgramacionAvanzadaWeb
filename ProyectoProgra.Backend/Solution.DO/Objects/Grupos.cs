using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
   public class Grupos
    {
        public Grupos()
        {
            Calificaciones = new HashSet<Calificaciones>();
            UsuarioXGrupos = new HashSet<UsuarioXGrupo>();
        }

        public int? IdGrupo { get; set; }
        public int IdGrado { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Grados IdGradoNavigation { get; set; }
        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
        public virtual ICollection<UsuarioXGrupo> UsuarioXGrupos { get; set; }
    }
}
