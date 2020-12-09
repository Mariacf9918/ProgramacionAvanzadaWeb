using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryCalificaciones : Repository<Calificaciones>, IRepositoryCalificaciones
    {
        public RepositoryCalificaciones(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Calificaciones>> GetAllWithAsync()
        {
            return await SolutionDBContext.Calificaciones.Include(a => a.IdGrupoNavigation)
                .Include(a => a.CedulaNavigation).Include(a => a.IdMateriaNavigation).
                Include(a => a.IdPeriodoNavigation).Include(a => a.IdTipoOperacionNavigation).ToListAsync();
        }

        public async Task<Calificaciones> GetByIdAsync(int id)
        {
            return await SolutionDBContext.Calificaciones.
               Include(a => a.IdGrupoNavigation).Include(a => a.CedulaNavigation).Include(a => a.IdMateriaNavigation)
               .Include(a => a.IdPeriodoNavigation).Include(a => a.IdTipoOperacionNavigation).
               SingleOrDefaultAsync(z => z.IdCalificacion == id);
        }

        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
