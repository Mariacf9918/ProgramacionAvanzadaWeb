using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
   public interface IRepositoryTipoOperaciones : IRepository<TipoOperaciones>
    {
        Task<IEnumerable<TipoOperaciones>> GetAllWithAsync();
        Task<TipoOperaciones> GetByIdAsync(int id);
    }
}
