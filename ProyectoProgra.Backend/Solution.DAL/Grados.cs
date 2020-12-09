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
    public class Grados : ICRUD<data.Grados>
    {
        private RepositoryGrados _repository = null;
        public Grados(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryGrados(solutionDBContext);
        }
        public void Delete(data.Grados t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Grados> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<data.Grados>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.Grados GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.Grados> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Insert(data.Grados t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Grados t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
