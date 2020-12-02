using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class UsuarioXInstitucionViewComponent : ViewComponent
    {
        public IRepositoryUsuarioXInstitucion repositoryUsuarioXInstitucion { get; set; }

        public UsuarioXInstitucionViewComponent(IRepositoryUsuarioXInstitucion repository)
        {
            repositoryUsuarioXInstitucion = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryUsuarioXInstitucion.ObtenerTodos());
        }
    }
}
