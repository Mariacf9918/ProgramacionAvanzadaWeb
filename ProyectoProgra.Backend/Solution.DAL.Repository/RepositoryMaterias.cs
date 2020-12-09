using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryMaterias : Repository<Materias>, IRepositoryMaterias
    {
        public RepositoryMaterias(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Materias>> GetAllWithAsync()
        {
            return await SolutionDBContext.Materias.Include(a => a.IdInstitucionNavigation).ToListAsync();
        }

        public async Task<Materias> GetByIdAsync(int id)
        {
            return await SolutionDBContext.Materias.
                Include(a => a.IdInstitucionNavigation).
                SingleOrDefaultAsync(z => z.IdMateria == id);
        }
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
