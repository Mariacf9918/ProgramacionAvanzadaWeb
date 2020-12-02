using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Usuarios
    {
        [Key]
        public int? Cedula { get; set; }
        public string Contrasena { get; set; }
        public string NombreCompleto { get; set; }
        public int Telefono { get; set; }
        public int IdRol { get; set; }

    }
}
