using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class TipoPeriodoViewComponent : ViewComponent
    {
        public IRepositoryTipoPeriodo repositoryTipoPeriodo { get; set; }

        public TipoPeriodoViewComponent(IRepositoryTipoPeriodo repository)
        {
            repositoryTipoPeriodo = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryTipoPeriodo.ObtenerTodos());
        }
    }
}
