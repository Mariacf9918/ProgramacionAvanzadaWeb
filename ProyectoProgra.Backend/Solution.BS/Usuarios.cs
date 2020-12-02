using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Usuarios : ICRUD<data.Usuarios>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Usuarios(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Usuarios t)
        {
            new Solution.DAL.Usuarios(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Usuarios> GetAll()
        {
            return new Solution.DAL.Usuarios(_solutionDBContext).GetAll();
        }

        public data.Usuarios GetOneById(int id)
        {
            return new Solution.DAL.Usuarios(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Usuarios t)
        {
            t.Cedula = null;
            new Solution.DAL.Usuarios(_solutionDBContext).Insert(t);
        }

        public void Update(data.Usuarios t)
        {
            new Solution.DAL.Usuarios(_solutionDBContext).Update(t);
        }
    }
}
