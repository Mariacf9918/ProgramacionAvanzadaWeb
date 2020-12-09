using Microsoft.EntityFrameworkCore;
using Solution.DAL.EF;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public class RepositoryUsuarios : Repository<Usuarios>, IRepositoryUsuarios
    {
        //Constructor correspondiente a la clase
        //Parametro Context para poderlo recibir y utilizar
        public RepositoryUsuarios(SolutionDBContext context) : base(context)
        { }
        public async Task<IEnumerable<Usuarios>> GetAllWithAsync()
        {
            return await SolutionDBContext.Usuarios.Include(a => a.IdRolNavigation).ToListAsync();
        }

        public async Task<Usuarios> GetWithByIdAsync(int id)
        {
            return await SolutionDBContext.Usuarios.
              Include(a => a.IdRolNavigation).
              SingleOrDefaultAsync(z => z.Cedula == id);
        }
        private SolutionDBContext SolutionDBContext
        {
            get { return dBContext as SolutionDBContext; }
        }
    }
}
