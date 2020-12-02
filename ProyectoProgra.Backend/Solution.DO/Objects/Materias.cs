﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Solution.DO.Objects
{
    public class Materias
    {
        [Key]
        public int? IdMateria { get; set; }
        public string Descripcion { get; set; }
        public int IdInstitucion { get; set; }
    }
}
