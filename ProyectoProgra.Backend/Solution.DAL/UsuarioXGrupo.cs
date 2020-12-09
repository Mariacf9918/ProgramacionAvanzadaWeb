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
    public class UsuarioXGrupo : ICRUD<data.UsuarioXGrupo>
    {
        private RepositoryUsuarioXGrupo _repository = null;
        public UsuarioXGrupo(SolutionDBContext solutionDBContext)
        {
            _repository = new RepositoryUsuarioXGrupo(solutionDBContext);
        }
        public void Delete(data.UsuarioXGrupo t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.UsuarioXGrupo> GetAll()
        {
            return _repository.GetAll();
        }

        public async Task<IEnumerable<data.UsuarioXGrupo>> GetAllInclude()
        {
            return await _repository.GetAllWithAsync();
        }

        public data.UsuarioXGrupo GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public async Task<data.UsuarioXGrupo> GetOneByIdInclude(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Insert(data.UsuarioXGrupo t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.UsuarioXGrupo t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
