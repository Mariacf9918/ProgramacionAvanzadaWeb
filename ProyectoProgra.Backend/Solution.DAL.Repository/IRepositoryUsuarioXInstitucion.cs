using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepositoryUsuarioXInstitucion : IRepository<UsuarioXInstitucion>
    {
        Task<IEnumerable<UsuarioXInstitucion>> GetAllWithAsync();
        Task<UsuarioXInstitucion> GetByIdAsync(int id);
    }
}
