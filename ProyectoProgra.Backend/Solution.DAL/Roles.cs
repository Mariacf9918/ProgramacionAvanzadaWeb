using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Roles : ICRUD<data.Roles>
    {
        private Repository<data.Roles> _repository = null;
        public Roles(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Roles>(solutionDBContext);
        }
        public void Delete(data.Roles t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Roles GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Roles t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Roles t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
