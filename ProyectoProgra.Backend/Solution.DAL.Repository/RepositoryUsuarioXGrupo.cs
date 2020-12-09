using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryUsuarioXGrupo : Repository<UsuarioXGrupo>, IRepositoryUsuarioXGrupo
    {
        public RepositoryUsuarioXGrupo(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<UsuarioXGrupo>> GetAllWithAsync()
        {
            return await SolutionDBContext.UsuarioXGrupo.Include(a => a.IdGrupoNavigation).Include(a => a.CedulaNavigation).ToListAsync();
        }

        public async Task<UsuarioXGrupo> GetByIdAsync(int id)
        {
            return await SolutionDBContext.UsuarioXGrupo.
              Include(a => a.IdGrupoNavigation).Include(a => a.CedulaNavigation).
              SingleOrDefaultAsync(z => z.IdUsuarioXgrupo == id);
        }

        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
