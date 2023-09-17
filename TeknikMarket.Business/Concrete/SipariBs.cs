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
    public class SipariBs:ISipariBS
    {
        private ISipariRepository repo;
        public SipariBs(ISipariRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(Sipari entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Sipari Get(Expression<Func<Sipari, bool>> fSipariter, params string[] includelist)
        {
            return repo.Get(fSipariter, includelist);
        }

        public List<Sipari> GetAll(Expression<Func<Sipari, bool>> fSipariter, params string[] includelist)
        {
            return repo.GetAll(fSipariter, includelist);
        }

        public Sipari GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(Sipari entity)
        {
            repo.Insert(entity);
        }

        public void Update(Sipari entity)
        {
            repo.Update(entity);
        }
    }
}
