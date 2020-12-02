using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class TipoOperaciones : ICRUD<data.TipoOperaciones>
    {
        private SolutionDBContext _solutionDBContext = null;
        public TipoOperaciones(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.TipoOperaciones t)
        {
            new Solution.DAL.TipoOperaciones(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.TipoOperaciones> GetAll()
        {
            return new Solution.DAL.TipoOperaciones(_solutionDBContext).GetAll();
        }

        public data.TipoOperaciones GetOneById(int id)
        {
            return new Solution.DAL.TipoOperaciones(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.TipoOperaciones t)
        {
            t.IdTipoOperacion = null;
            new Solution.DAL.TipoOperaciones(_solutionDBContext).Insert(t);
        }

        public void Update(data.TipoOperaciones t)
        {
            new Solution.DAL.TipoOperaciones(_solutionDBContext).Update(t);
        }
    }
}
