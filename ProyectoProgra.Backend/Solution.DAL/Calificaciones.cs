using Solution.DAL.EF;
using Solution.DAL.Repository;
using Solution.DO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using data = Solution.DO.Objects;

namespace Solution.DAL
{
    public class Calificaciones : ICRUD<data.Calificaciones>
    {
        private Repository<data.Calificaciones> _repository = null;
        public Calificaciones(SolutionDBContext solutionDBContext)
        {
            _repository = new Repository<data.Calificaciones>(solutionDBContext);
        }
        public void Delete(data.Calificaciones t)
        {
            _repository.Delete(t);
            _repository.Commit();
        }

        public IEnumerable<data.Calificaciones> GetAll()
        {
            return _repository.GetAll();
        }

        public data.Calificaciones GetOneById(int id)
        {
            return _repository.GetOneById(id);
        }

        public void Insert(data.Calificaciones t)
        {
            _repository.Insert(t);
            _repository.Commit();
        }

        public void Update(data.Calificaciones t)
        {
            _repository.Update(t);
            _repository.Commit();
        }
    }
}
