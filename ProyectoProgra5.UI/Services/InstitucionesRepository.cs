using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class InstitucionesRepository : IRepositoryInstituciones
    {
        public ProyectoProgramacionWebContext DbContext;

        public InstitucionesRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Institucione> ObtenerTodos()
        {
            return DbContext.Instituciones.ToList();
        }
    }
}
