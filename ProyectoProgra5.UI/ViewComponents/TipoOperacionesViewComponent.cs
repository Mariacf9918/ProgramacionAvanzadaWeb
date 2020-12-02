using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class TipoOperacionesViewComponent : ViewComponent
    {
        public IRepositoryTipoOperaciones repositoryTipoOperaciones { get; set; }

        public TipoOperacionesViewComponent(IRepositoryTipoOperaciones repository)
        {
            repositoryTipoOperaciones = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryTipoOperaciones.ObtenerTodos());
        }
    }
}
