using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryUsuarioXInstitucion : Repository<UsuarioXInstitucion>, IRepositoryUsuarioXInstitucion
    {
        public RepositoryUsuarioXInstitucion(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<UsuarioXInstitucion>> GetAllWithAsync()
        {
            return await SolutionDBContext.UsuarioXInstitucion.Include(a => a.IdInstitucionNavigation).Include(a => a.CedulaNavigation).ToListAsync();
        }

        public async Task<UsuarioXInstitucion> GetByIdAsync(int id)
        {
            return await SolutionDBContext.UsuarioXInstitucion.
               Include(a => a.IdInstitucionNavigation).Include(a => a.CedulaNavigation).
               SingleOrDefaultAsync(z => z.IdUsuarioXInstitucion == id);
        }

        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
