using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.BS
{
    public class Calificaciones : ICRUD<data.Calificaciones>
    {
        private SolutionDBContext _solutionDBContext = null;
        public Calificaciones(SolutionDBContext solutionDBContext)
        {
            _solutionDBContext = solutionDBContext;
        }
        public void Delete(data.Calificaciones t)
        {
            new Solution.DAL.Calificaciones(_solutionDBContext).Delete(t);
        }

        public IEnumerable<data.Calificaciones> GetAll()
        {
            return new Solution.DAL.Calificaciones(_solutionDBContext).GetAll();
        }

        public data.Calificaciones GetOneById(int id)
        {
            return new Solution.DAL.Calificaciones(_solutionDBContext).GetOneById(id);
        }

        public void Insert(data.Calificaciones t)
        {
            t.IdCalificacion = null;
            new Solution.DAL.Calificaciones(_solutionDBContext).Insert(t);
        }

        public void Update(data.Calificaciones t)
        {
            new Solution.DAL.Calificaciones(_solutionDBContext).Update(t);
        }
    }
}
