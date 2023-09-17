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
    public class SepetBs:ISepetBs
    {
        private ISepetRepository repo;
        public SepetBs(ISepetRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(Sepet entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Sepet Get(Expression<Func<Sepet, bool>> fSepetter, params string[] includelist)
        {
            return repo.Get(fSepetter, includelist);
        }

        public List<Sepet> GetAll(Expression<Func<Sepet, bool>> fSepetter, params string[] includelist)
        {
            return repo.GetAll(fSepetter, includelist);
        }

        public Sepet GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(Sepet entity)
        {
            repo.Insert(entity);
        }

        public void Update(Sepet entity)
        {
            repo.Update(entity);
        }
    }
}
