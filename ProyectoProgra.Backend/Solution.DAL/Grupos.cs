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
    public class Grupos : ICRUD<data.Grupos>
    {
        private RepositoryGrupos _repository = null;
        public Grupos(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryGrupos(solutionDBContext);
        }
        public void Delete(data.Grupos t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Grupos> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<data.Grupos>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.Grupos GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.Grupos> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Insert(data.Grupos t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Grupos t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
