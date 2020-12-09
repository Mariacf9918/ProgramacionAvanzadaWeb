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
    public class TipoOperaciones : ICRUD<data.TipoOperaciones>
    {
        private RepositoryTipoOperaciones _repository = null;
        public TipoOperaciones(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryTipoOperaciones(solutionDBContext);
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

        public async Task<IEnumerable<data.TipoOperaciones>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.TipoOperaciones GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.TipoOperaciones> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
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
