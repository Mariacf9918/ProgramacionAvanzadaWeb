﻿using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Materias : ICRUD<data.Materias>
    {
        private Repository<data.Materias> _repository = null;
        public Materias(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Materias>(solutionDBContext);
        }
        public void Delete(data.Materias t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Materias> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Materias GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Materias t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Materias t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
