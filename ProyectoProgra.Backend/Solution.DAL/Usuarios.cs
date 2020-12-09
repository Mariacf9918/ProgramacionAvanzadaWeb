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
    public class Usuarios : ICRUD<data.Usuarios>
    {
        private RepositoryUsuarios _repository = null;
        public Usuarios(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryUsuarios(solutionDBContext);
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

        public async Task<IEnumerable<data.Usuarios>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.Usuarios GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.Usuarios> GetOneByIdInclude(int id)
        {
            return await _repository.GetWithByIdAsync(id);
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
