using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Instituciones : ICRUD<data.Instituciones>
    {
        private Repository<data.Instituciones> _repository = null;
        public Instituciones(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Instituciones>(solutionDBContext);
        }
        public void Delete(data.Instituciones t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Instituciones> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Instituciones GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Instituciones t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Instituciones t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
