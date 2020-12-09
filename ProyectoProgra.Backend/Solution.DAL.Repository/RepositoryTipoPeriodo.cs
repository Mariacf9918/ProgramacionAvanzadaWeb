using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryTipoPeriodo : Repository<TipoPeriodo>, IRepositoryTipoPeriodo
    {
        public RepositoryTipoPeriodo(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<TipoPeriodo>> GetAllWithAsync()
        {
            return await SolutionDBContext.TipoPeriodo.Include(a => a.IdInstitucionNavigation).ToListAsync();
        }

        public async Task<TipoPeriodo> GetByIdAsync(int id)
        {
            return await SolutionDBContext.TipoPeriodo.
                 Include(a => a.IdInstitucionNavigation).
                 SingleOrDefaultAsync(z => z.IdPeriodo == id);
        }
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
