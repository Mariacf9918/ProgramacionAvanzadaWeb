using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryGrupos : Repository<Grupos>, IRepositoryGrupos
    {
        public RepositoryGrupos(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Grupos>> GetAllWithAsync()
        {
            return await SolutionDBContext.Grupos.Include(a => a.IdInstitucionNavigation).Include(a => a.IdGradoNavigation).ToListAsync();
        }

        public async Task<Grupos> GetByIdAsync(int id)
        {
            return await SolutionDBContext.Grupos.
                Include(a => a.IdInstitucionNavigation).Include(a => a.IdGradoNavigation).
                SingleOrDefaultAsync(z => z.IdGrupo == id);
        }
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
