using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Grupos : ICRUD<data.Grupos>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Grupos(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Grupos t)
        {
            new Solution.DAL.Grupos(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Grupos> GetAll()
        {
            return new Solution.DAL.Grupos(_solutionDBContext).GetAll();
        }

        public async Task<IEnumerable<data.Grupos>> GetAllInclude()
        {
            return await new DAL.Grupos(_solutionDBContext).GetAllInclude();
        }
        public data.Grupos GetOneById(int id)
        {
            return new Solution.DAL.Grupos(_solutionDBContext).GetOneById(id);
        }

        public async Task<data.Grupos> GetOneByIdInclude(int id)
        {
            return await new DAL.Grupos(_solutionDBContext).GetOneByIdInclude(id);
        }

        public void Insert(data.Grupos t)
        {
            t.IdGrupo = null;
            new Solution.DAL.Grupos(_solutionDBContext).Insert(t);
        }

        public void Update(data.Grupos t)
        {
            new Solution.DAL.Grupos(_solutionDBContext).Update(t);
        }
    }
}
