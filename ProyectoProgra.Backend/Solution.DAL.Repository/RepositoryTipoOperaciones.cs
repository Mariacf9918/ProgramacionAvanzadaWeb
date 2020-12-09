using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryTipoOperaciones : Repository<TipoOperaciones>, IRepositoryTipoOperaciones
    {
        public RepositoryTipoOperaciones(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<TipoOperaciones>> GetAllWithAsync()
        {
            return await SolutionDBContext.TipoOperaciones.Include(a => a.IdInstitucionNavigation).ToListAsync();
        }

        public async Task<TipoOperaciones> GetByIdAsync(int id)
        {
            return await SolutionDBContext.TipoOperaciones.
                 Include(a => a.IdInstitucionNavigation).
                 SingleOrDefaultAsync(z => z.IdTipoOperacion == id);
        }
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }

    }
}
