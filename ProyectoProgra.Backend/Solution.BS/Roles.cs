using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Roles : ICRUD<data.Roles>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Roles(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Roles t)
        {
            new Solution.DAL.Roles(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Roles> GetAll()
        {
            return new Solution.DAL.Roles(_solutionDBContext).GetAll();
        }

        public data.Roles GetOneById(int id)
        {
            return new Solution.DAL.Roles(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Roles t)
        {
            t.IdRol = null;
            new Solution.DAL.Roles(_solutionDBContext).Insert(t);
        }

        public void Update(data.Roles t)
        {
            new Solution.DAL.Roles(_solutionDBContext).Update(t);
        }
    }
}
