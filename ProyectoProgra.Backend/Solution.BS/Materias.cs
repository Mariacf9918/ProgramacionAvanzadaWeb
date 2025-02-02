﻿using Solution.DAL.EF;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<data.Materias>> GetAllInclude()
        {
            return await new DAL.Materias(_solutionDBContext).GetAllInclude();
        }

        public data.Materias GetOneById(int id)
        {
            return new Solution.DAL.Materias(_solutionDBContext).GetOneById(id);
        }

        public async Task<data.Materias> GetOneByIdInclude(int id)
        {
            return await new DAL.Materias(_solutionDBContext).GetOneByIdInclude(id);
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
