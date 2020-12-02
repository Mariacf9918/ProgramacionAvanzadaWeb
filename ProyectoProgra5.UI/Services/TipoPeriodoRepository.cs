using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class TipoPeriodoRepository : IRepositoryTipoPeriodo
    {
        public ProyectoProgramacionWebContext DbContext;

        public TipoPeriodoRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<TipoPeriodo> ObtenerTodos()
        {
            return DbContext.TipoPeriodos.ToList();
        }
    }
}
