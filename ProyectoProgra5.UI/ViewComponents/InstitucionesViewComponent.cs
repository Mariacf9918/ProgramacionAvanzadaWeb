using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class InstitucionesViewComponent : ViewComponent
    {
        public IRepositoryInstituciones repositoryInstituciones { get; set; }

        public InstitucionesViewComponent(IRepositoryInstituciones repository)
        {
            repositoryInstituciones = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryInstituciones.ObtenerTodos());
        }
    }
}
