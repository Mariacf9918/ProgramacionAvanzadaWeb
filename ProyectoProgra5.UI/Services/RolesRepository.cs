using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class RolesRepository : IRepositoryRoles
    {
        public ProyectoProgramacionWebContext DbContext;

        public RolesRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Role> ObtenerTodos()
        {
            return DbContext.Roles.ToList();
        }
    }
}
