using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class CalificacionesViewComponent : ViewComponent
    {
        public IRepositoryCalificaciones repositoryCalificaciones { get; set; }

        public CalificacionesViewComponent(IRepositoryCalificaciones repository)
        {
            repositoryCalificaciones = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryCalificaciones.ObtenerTodos());
        }
    }
}
