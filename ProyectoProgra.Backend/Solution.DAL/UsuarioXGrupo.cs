using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class UsuarioXGrupo : ICRUD<data.UsuarioXGrupo>
    {
        private Repository<data.UsuarioXGrupo> _repository = null;
        public UsuarioXGrupo(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.UsuarioXGrupo>(solutionDBContext);
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

        public data.UsuarioXGrupo GetOneById(int id)
        {
            return _repository.GetOneById(id);
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
