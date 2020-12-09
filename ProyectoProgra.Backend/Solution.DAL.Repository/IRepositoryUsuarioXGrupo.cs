using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepositoryUsuarioXGrupo : IRepository<UsuarioXGrupo>
    {
        Task<IEnumerable<UsuarioXGrupo>> GetAllWithAsync();
        Task<UsuarioXGrupo> GetByIdAsync(int id);
    }
}
