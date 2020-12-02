using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Grupos : ICRUD<data.Grupos>
    {
        private Repository<data.Grupos> _repository = null;
        public Grupos(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Grupos>(solutionDBContext);
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

        public data.Grupos GetOneById(int id)
        {
            return _repository.GetOneById(id);
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
