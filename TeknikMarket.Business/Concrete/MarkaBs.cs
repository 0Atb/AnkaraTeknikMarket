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
    public class MarkaBs:IMarkaBS
    {
        private IMarkaRepository repo;
        public MarkaBs(IMarkaRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(Marka entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Marka Get(Expression<Func<Marka, bool>> fMarkater, params string[] includelist)
        {
            return repo.Get(fMarkater, includelist);
        }

        public List<Marka> GetAll(Expression<Func<Marka, bool>> fMarkater, params string[] includelist)
        {
            return repo.GetAll(fMarkater, includelist);
        }

        public Marka GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(Marka entity)
        {
            repo.Insert(entity);
        }

        public void Update(Marka entity)
        {
            repo.Update(entity);
        }
    }
}
