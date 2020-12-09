using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class UsuarioXGrupoRepository : IRepositoryUsuarioXGrupo
    {
        public ProyectoProgramacionWebContext DbContext;

        public UsuarioXGrupoRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<UsuarioXGrupo> ObtenerTodos()
        {
            return DbContext.UsuarioXGrupos.ToList();
        }
    }
}
