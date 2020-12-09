using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
   public class Grados
    {
        public Grados()
        {
            Grupos = new HashSet<Grupos>();
        }

        public int? IdGrado { get; set; }
        public string Descripcion { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual ICollection<Grupos> Grupos { get; set; }
    }
}
