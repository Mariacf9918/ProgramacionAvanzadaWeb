using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
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

        public data.Grupos GetOneById(int id)
        {
            return new Solution.DAL.Grupos(_solutionDBContext).GetOneById(id);
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
