using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Roles
    {
       
        public Roles()
        {
            Usuarios = new HashSet<Usuarios>();
        }

        public int? IdRol { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Usuarios> Usuarios { get; set; }
    }
}
