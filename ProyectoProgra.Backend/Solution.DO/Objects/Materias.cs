using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Materias
    {
        public Materias()
        {
            Calificaciones = new HashSet<Calificaciones>();
        }

        public int? IdMateria { get; set; }
        public string Descripcion { get; set; }
        public int IdInstitucion { get; set; }

        public virtual Instituciones IdInstitucionNavigation { get; set; }
        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
    }
}
