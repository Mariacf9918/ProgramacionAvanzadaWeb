using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class TipoPeriodo : ICRUD<data.TipoPeriodo>
    {
        private Repository<data.TipoPeriodo> _repository = null;
        public TipoPeriodo(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.TipoPeriodo>(solutionDBContext);
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

        public data.TipoPeriodo GetOneById(int id)
        {
            return _repository.GetOneById(id);
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
