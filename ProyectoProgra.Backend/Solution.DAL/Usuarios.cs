using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Usuarios : ICRUD<data.Usuarios>
    {
        private Repository<data.Usuarios> _repository = null;
        public Usuarios(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Usuarios>(solutionDBContext);
        }
        public void Delete(data.Usuarios t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Usuarios GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Usuarios t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Usuarios t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
