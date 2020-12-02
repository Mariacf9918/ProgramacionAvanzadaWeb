using Microsoft.AspNetCore.Mvc;
using ProyectoProgra5.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.ViewComponents
{
    public class RolesViewComponent : ViewComponent
    {
        public IRepositoryRoles repositoryRoles { get; set; }

        public RolesViewComponent(IRepositoryRoles repository)
        {
            repositoryRoles = repository;
        }

        public IViewComponentResult Invoke()
        {
            return View(repositoryRoles.ObtenerTodos());
        }
    }
}
