using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Materias : ICRUD<data.Materias>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Materias(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Materias t)
        {
            new Solution.DAL.Materias(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Materias> GetAll()
        {
            return new Solution.DAL.Materias(_solutionDBContext).GetAll();
        }

        public data.Materias GetOneById(int id)
        {
            return new Solution.DAL.Materias(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Materias t)
        {
            t.IdMateria = null;
            new Solution.DAL.Materias(_solutionDBContext).Insert(t);
        }

        public void Update(data.Materias t)
        {
            new Solution.DAL.Materias(_solutionDBContext).Update(t);
        }
    }
}
