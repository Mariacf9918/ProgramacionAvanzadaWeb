using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class UsuariosViewComponent : ViewComponent
    {
        public IRepositoryUsuarios repositoryUsuarios { get; set; }

        public UsuariosViewComponent(IRepositoryUsuarios repository)
        {
            repositoryUsuarios = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryUsuarios.ObtenerTodos());
        }
    }
}
