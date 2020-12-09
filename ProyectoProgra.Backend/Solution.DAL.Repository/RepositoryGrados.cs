using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryGrados : Repository<Grados>, IRepositoryGrados
    {
        public RepositoryGrados(SolutionDBContext context) : base(context)
        { }

        public async Task<IEnumerable<Grados>> GetAllWithAsync()
        {
            return await SolutionDBContext.Grados.Include(a => a.IdInstitucionNavigation).ToListAsync();
        }

        public async Task<Grados> GetByIdAsync(int id)
        {
            return await SolutionDBContext.Grados.
               Include(a => a.IdInstitucionNavigation).
               SingleOrDefaultAsync(z => z.IdGrado == id);
        }

        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
