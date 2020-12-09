using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class UsuarioXInstitucion : ICRUD<data.UsuarioXInstitucion>
    {
        private SolutionDBContext _solutionDBContext = null;
        public UsuarioXInstitucion(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.UsuarioXInstitucion t)
        {
            new Solution.DAL.UsuarioXInstitucion(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.UsuarioXInstitucion> GetAll()
        {
            return new Solution.DAL.UsuarioXInstitucion(_solutionDBContext).GetAll();
        }

        public async Task<IEnumerable<data.UsuarioXInstitucion>> GetAllInclude()
        {
            return await new DAL.UsuarioXInstitucion(_solutionDBContext).GetAllInclude();
        }

        public data.UsuarioXInstitucion GetOneById(int id)
        {
            return new Solution.DAL.UsuarioXInstitucion(_solutionDBContext).GetOneById(id);
        }

        public async Task<data.UsuarioXInstitucion> GetOneByIdInclude(int id)
        {
            return await new DAL.UsuarioXInstitucion(_solutionDBContext).GetOneByIdInclude(id);
        }

        public void Insert(data.UsuarioXInstitucion t)
        {
            t.IdUsuarioXInstitucion = null;
            new Solution.DAL.UsuarioXInstitucion(_solutionDBContext).Insert(t);
        }

        public void Update(data.UsuarioXInstitucion t)
        {
            new Solution.DAL.UsuarioXInstitucion(_solutionDBContext).Update(t);
        }
    }
}
