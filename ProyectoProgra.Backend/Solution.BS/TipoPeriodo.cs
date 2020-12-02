using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class TipoPeriodo : ICRUD<data.TipoPeriodo>
    {
        private SolutionDBContext _solutionDBContext = null;
        public TipoPeriodo(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.TipoPeriodo t)
        {
            new Solution.DAL.TipoPeriodo(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.TipoPeriodo> GetAll()
        {
            return new Solution.DAL.TipoPeriodo(_solutionDBContext).GetAll();
        }

        public data.TipoPeriodo GetOneById(int id)
        {
            return new Solution.DAL.TipoPeriodo(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.TipoPeriodo t)
        {
            t.IdPeriodo = null;
            new Solution.DAL.TipoPeriodo(_solutionDBContext).Insert(t);
        }

        public void Update(data.TipoPeriodo t)
        {
            new Solution.DAL.TipoPeriodo(_solutionDBContext).Update(t);
        }
    }
}
