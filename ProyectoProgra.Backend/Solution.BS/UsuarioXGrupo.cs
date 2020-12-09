using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class UsuarioXGrupo : ICRUD<data.UsuarioXGrupo>
    {
        private SolutionDBContext _solutionDBContext = null;
        public UsuarioXGrupo(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.UsuarioXGrupo t)
        {
            new Solution.DAL.UsuarioXGrupo(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.UsuarioXGrupo> GetAll()
        {
            return new Solution.DAL.UsuarioXGrupo(_solutionDBContext).GetAll();
        }

        public async Task<IEnumerable<data.UsuarioXGrupo>> GetAllInclude()
        {
            return await new DAL.UsuarioXGrupo(_solutionDBContext).GetAllInclude();
        }

        public data.UsuarioXGrupo GetOneById(int id)
        {
            return new Solution.DAL.UsuarioXGrupo(_solutionDBContext).GetOneById(id);
        }

        public async Task<data.UsuarioXGrupo> GetOneByIdInclude(int id)
        {
            return await new DAL.UsuarioXGrupo(_solutionDBContext).GetOneByIdInclude(id);
        }

        public void Insert(data.UsuarioXGrupo t)
        {
            t.IdUsuarioXgrupo = null;
            new Solution.DAL.UsuarioXGrupo(_solutionDBContext).Insert(t);
        }

        public void Update(data.UsuarioXGrupo t)
        {
            new Solution.DAL.UsuarioXGrupo(_solutionDBContext).Update(t);
        }
    }
}
