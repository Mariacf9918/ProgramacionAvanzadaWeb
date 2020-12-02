using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class UsuariosRepository : IRepositoryUsuarios
    {
        public ProyectoProgramacionWebContext DbContext;

        public UsuariosRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Usuario> ObtenerTodos()
        {
            return DbContext.Usuarios.ToList();
        }
    }
}
