using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepositoryTipoPeriodo : IRepository<TipoPeriodo>
    {
        Task<IEnumerable<TipoPeriodo>> GetAllWithAsync();
        Task<TipoPeriodo> GetByIdAsync(int id);
    }
}
