using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
   public interface IRepositoryGrupos : IRepository<Grupos>
    {
        Task<IEnumerable<Grupos>> GetAllWithAsync();
        Task<Grupos> GetByIdAsync(int id);
    }
}
