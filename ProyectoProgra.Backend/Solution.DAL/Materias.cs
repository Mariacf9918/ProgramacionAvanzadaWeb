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
    public class Materias : ICRUD<data.Materias>
    {
        private RepositoryMaterias _repository = null;
        public Materias(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryMaterias(solutionDBContext);
        }
        public void Delete(data.Materias t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Materias> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<data.Materias>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.Materias GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.Materias> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Insert(data.Materias t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Materias t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
