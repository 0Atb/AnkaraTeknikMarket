using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.Business.Abstract;
using TeknikMarket.DataAccess.Abstract;
using TeknikMarket.Model.Entity;

namespace TeknikMarket.Business.Concrete
{
    public class TaksitSecenekBs:ITaksitSecenekBS
    {
        private ITaksitSecenekRepository repo;
        public TaksitSecenekBs(ITaksitSecenekRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(TaksitSecenek entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public TaksitSecenek Get(Expression<Func<TaksitSecenek, bool>> fTaksitSecenekter, params string[] includelist)
        {
            return repo.Get(fTaksitSecenekter, includelist);
        }

        public List<TaksitSecenek> GetAll(Expression<Func<TaksitSecenek, bool>> fTaksitSecenekter, params string[] includelist)
        {
            return repo.GetAll(fTaksitSecenekter, includelist);
        }

        public TaksitSecenek GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(TaksitSecenek entity)
        {
            repo.Insert(entity);
        }

        public void Update(TaksitSecenek entity)
        {
            repo.Update(entity);
        }
    }
}
