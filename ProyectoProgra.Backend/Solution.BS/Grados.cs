using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Grados : ICRUD<data.Grados>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Grados(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Grados t)
        {
            new Solution.DAL.Grados(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Grados> GetAll()
        {
            return new Solution.DAL.Grados(_solutionDBContext).GetAll();
        }

        public data.Grados GetOneById(int id)
        {
            return new Solution.DAL.Grados(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Grados t)
        {
            t.IdGrado = null;
            new Solution.DAL.Grados(_solutionDBContext).Insert(t);
        }

        public void Update(data.Grados t)
        {
            new Solution.DAL.Grados(_solutionDBContext).Update(t);
        }
    }
}
