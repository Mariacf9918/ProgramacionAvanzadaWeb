using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class UsuarioXInstitucion : ICRUD<data.UsuarioXInstitucion>
    {
        private Repository<data.UsuarioXInstitucion> _repository = null;
        public UsuarioXInstitucion(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.UsuarioXInstitucion>(solutionDBContext);
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

        public data.UsuarioXInstitucion GetOneById(int id)
        {
            return _repository.GetOneById(id);
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
