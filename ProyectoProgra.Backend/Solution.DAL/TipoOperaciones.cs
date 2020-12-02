using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class TipoOperaciones : ICRUD<data.TipoOperaciones>
    {
        private Repository<data.TipoOperaciones> _repository = null;
        public TipoOperaciones(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.TipoOperaciones>(solutionDBContext);
        }
        public void Delete(data.TipoOperaciones t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.TipoOperaciones> GetAll()
        {
            return _repository.GetAll();
        }

        public data.TipoOperaciones GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.TipoOperaciones t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.TipoOperaciones t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
