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
    public class SehirBs:ISehirBS
    {
        private ISehirRepository repo;
        public SehirBs(ISehirRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(Sehir entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Sehir Get(Expression<Func<Sehir, bool>> fSehirter, params string[] includelist)
        {
            return repo.Get(fSehirter, includelist);
        }

        public List<Sehir> GetAll(Expression<Func<Sehir, bool>> fSehirter, params string[] includelist)
        {
            return repo.GetAll(fSehirter, includelist);
        }

        public Sehir GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(Sehir entity)
        {
            repo.Insert(entity);
        }

        public void Update(Sehir entity)
        {
            repo.Update(entity);
        }
    }
}
