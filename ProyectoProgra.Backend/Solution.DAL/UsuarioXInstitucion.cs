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
    public class UsuarioXInstitucion : ICRUD<data.UsuarioXInstitucion>
    {
        private RepositoryUsuarioXInstitucion _repository = null;
        public UsuarioXInstitucion(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryUsuarioXInstitucion(solutionDBContext);
        }
        public void Delete(data.UsuarioXInstitucion t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.UsuarioXInstitucion> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<data.UsuarioXInstitucion>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.UsuarioXInstitucion GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.UsuarioXInstitucion> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Insert(data.UsuarioXInstitucion t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.UsuarioXInstitucion t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
