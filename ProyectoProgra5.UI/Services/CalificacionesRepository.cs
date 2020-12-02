﻿using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class CalificacionesRepository : IRepositoryCalificaciones
    {
        public ProyectoProgramacionWebContext DbContext;

        public CalificacionesRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        List<Calificacione> IRepositoryCalificaciones.ObtenerTodos()
        {
            return DbContext.Calificaciones.ToList();
        }
    }
}