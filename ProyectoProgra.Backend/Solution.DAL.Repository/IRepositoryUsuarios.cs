using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepositoryUsuarios : IRepository<Usuarios>
    {
        Task<IEnumerable<Usuarios>> GetAllWithAsync();
        Task<Usuarios> GetWithByIdAsync(int id);
    }
}
