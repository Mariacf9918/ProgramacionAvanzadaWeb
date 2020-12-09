using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepositoryGrados : IRepository<Grados>
    {
        Task<IEnumerable<Grados>> GetAllWithAsync();
        Task<Grados> GetByIdAsync(int id);
    }
}
