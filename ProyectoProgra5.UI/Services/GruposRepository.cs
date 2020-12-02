using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class GruposRepository : IRepositoryGrupos
    {
        public ProyectoProgramacionWebContext DbContext;

        public GruposRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Grupo> ObtenerTodos()
        {
            return DbContext.Grupos.ToList();
        }
    }
}
