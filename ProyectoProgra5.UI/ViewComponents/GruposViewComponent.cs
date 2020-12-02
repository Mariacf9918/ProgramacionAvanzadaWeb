using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class GruposViewComponent : ViewComponent
    {
        public IRepositoryGrupos repositoryGrupos { get; set; }

        public GruposViewComponent(IRepositoryGrupos repository)
        {
            repositoryGrupos = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryGrupos.ObtenerTodos());
        }
    }
}
