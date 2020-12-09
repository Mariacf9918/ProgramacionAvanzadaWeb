using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<data.Calificaciones>> GetAllInclude()
        {
            return await new DAL.Calificaciones(_solutionDBContext).GetAllInclude();
        }

        public data.Calificaciones GetOneById(int id)
        {
            return new Solution.DAL.Calificaciones(_solutionDBContext).GetOneById(id);
        }

        public async Task<data.Calificaciones> GetOneByIdInclude(int id)
        {
            return await new DAL.Calificaciones(_solutionDBContext).GetOneByIdInclude(id);
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
