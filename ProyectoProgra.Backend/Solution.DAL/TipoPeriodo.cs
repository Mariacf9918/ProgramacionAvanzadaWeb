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
    public class TipoPeriodo : ICRUD<data.TipoPeriodo>
    {
        private RepositoryTipoPeriodo _repository = null;
        public TipoPeriodo(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryTipoPeriodo(solutionDBContext);
        }
        public void Delete(data.TipoPeriodo t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.TipoPeriodo> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<data.TipoPeriodo>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.TipoPeriodo GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.TipoPeriodo> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Insert(data.TipoPeriodo t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.TipoPeriodo t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
