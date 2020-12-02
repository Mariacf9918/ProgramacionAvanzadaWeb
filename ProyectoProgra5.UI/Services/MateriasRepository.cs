using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class MateriasRepository : IRepositoryMaterias
    {
        public ProyectoProgramacionWebContext DbContext;

        public MateriasRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Materia> ObtenerTodos()
        {
            return DbContext.Materias.ToList();
        }
    }
}
