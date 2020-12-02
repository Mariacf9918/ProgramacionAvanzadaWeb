using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Instituciones : ICRUD<data.Instituciones>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Instituciones(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Instituciones t)
        {
            new Solution.DAL.Instituciones(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Instituciones> GetAll()
        {
            return new Solution.DAL.Instituciones(_solutionDBContext).GetAll();
        }

        public data.Instituciones GetOneById(int id)
        {
            return new Solution.DAL.Instituciones(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Instituciones t)
        {
            t.IdInstitucion = null;
            new Solution.DAL.Instituciones(_solutionDBContext).Insert(t);
        }

        public void Update(data.Instituciones t)
        {
            new Solution.DAL.Instituciones(_solutionDBContext).Update(t);
        }
    }
}
