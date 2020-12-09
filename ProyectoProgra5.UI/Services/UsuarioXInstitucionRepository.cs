using ProyectoProgra5.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoProgra5.UI.Services
{
    public class UsuarioXInstitucionRepository : IRepositoryUsuarioXInstitucion
    {
        public ProyectoProgramacionWebContext DbContext;

        public UsuarioXInstitucionRepository(ProyectoProgramacionWebContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<UsuarioXInstitucion> ObtenerTodos()
        {
            return DbContext.UsuarioXInstitucions.ToList();
        }

        
    }
}
