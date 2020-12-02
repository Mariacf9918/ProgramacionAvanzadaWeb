using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class MateriasViewComponent : ViewComponent
    {
        public IRepositoryMaterias repositoryMaterias { get; set; }

        public MateriasViewComponent(IRepositoryMaterias repository)
        {
            repositoryMaterias = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryMaterias.ObtenerTodos());
        }
    }
}
