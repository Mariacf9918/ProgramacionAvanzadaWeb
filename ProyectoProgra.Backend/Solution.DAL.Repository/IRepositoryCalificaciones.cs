using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.Repository
{
    public interface IRepositoryCalificaciones : IRepository<Calificaciones>
    {
        Task<IEnumerable<Calificaciones>> GetAllWithAsync();
        Task<Calificaciones> GetByIdAsync(int id);
    }
}
