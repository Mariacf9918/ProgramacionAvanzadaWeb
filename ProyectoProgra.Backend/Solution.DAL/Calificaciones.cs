using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Calificaciones : ICRUD<data.Calificaciones>
    {
        private RepositoryCalificaciones _repository = null;
        public Calificaciones(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryCalificaciones(solutionDBContext);
        }
        public void Delete(data.Calificaciones t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Calificaciones> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<data.Calificaciones>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.Calificaciones GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.Calificaciones> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Insert(data.Calificaciones t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Calificaciones t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
