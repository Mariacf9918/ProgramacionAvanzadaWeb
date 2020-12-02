using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Grados : ICRUD<data.Grados>
    {
        private Repository<data.Grados> _repository = null;
        public Grados(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Grados>(solutionDBContext);
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

        public data.Grados GetOneById(int id)
        {
            return _repository.GetOneById(id);
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
