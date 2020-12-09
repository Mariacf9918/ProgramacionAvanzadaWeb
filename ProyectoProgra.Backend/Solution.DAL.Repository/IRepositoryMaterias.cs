using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
     public interface IRepositoryMaterias : IRepository<Materias>
    {
        Task<IEnumerable<Materias>> GetAllWithAsync();
        Task<Materias> GetByIdAsync(int id);
    }
}
