using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public interface IRepositoryUsuarioXInstitucion
    {
        List<UsuarioXInstitucion> ObtenerTodos();
    }
}
