using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class TipoOperacionesRepository : IRepositoryTipoOperaciones
    {
        public ProyectoProgramacionWebContext DbContext;

        public TipoOperacionesRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<TipoOperacione> ObtenerTodos()
        {
            return DbContext.TipoOperaciones.ToList();
        }
    }
}
