using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.API.Models
{
    public class Instituciones
    {
        public int? IdInstitucion { get; set; }
        public string NombreInstitucion { get; set; }
        public string Descripcion { get; set; }
        public string Telefono { get; set; }
        public string Encargado { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
    }
}
