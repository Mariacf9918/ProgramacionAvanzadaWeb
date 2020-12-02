using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class UsuarioXGrupoViewComponent : ViewComponent
    {
        public IRepositoryUsuarioXGrupo repositoryUsuarioXGrupo { get; set; }

        public UsuarioXGrupoViewComponent(IRepositoryUsuarioXGrupo repository)
        {
            repositoryUsuarioXGrupo = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryUsuarioXGrupo.ObtenerTodos());
        }
    }
}
