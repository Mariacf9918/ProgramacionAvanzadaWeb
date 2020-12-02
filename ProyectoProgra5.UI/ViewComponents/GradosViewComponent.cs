using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class GradosViewComponent : ViewComponent
    {
        public IRepositoryGrados repositoryGrados { get; set; }

        public GradosViewComponent(IRepositoryGrados repository)
        {
            repositoryGrados = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryGrados.ObtenerTodos());
        }
    }
}
