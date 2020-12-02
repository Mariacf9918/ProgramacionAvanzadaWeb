using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class GradosRepository : IRepositoryGrados
    {
        public ProyectoProgramacionWebContext DbContext;

        public GradosRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }
        public List<Grado> ObtenerTodos()
        {
            return DbContext.Grados.ToList();
        }
    }
}
