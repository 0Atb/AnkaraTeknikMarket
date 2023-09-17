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
    public class YoneticiBs:IYoneticiBS
    {
        private IYoneticiRepository repo;
        public YoneticiBs(IYoneticiRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(Yonetici entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Yonetici Get(Expression<Func<Yonetici, bool>> fYoneticiter, params string[] includelist)
        {
            return repo.Get(fYoneticiter, includelist);
        }

        public List<Yonetici> GetAll(Expression<Func<Yonetici, bool>> fYoneticiter, params string[] includelist)
        {
            return repo.GetAll(fYoneticiter, includelist);
        }

        public Yonetici GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(Yonetici entity)
        {
            repo.Insert(entity);
        }

        public void Update(Yonetici entity)
        {
            repo.Update(entity);
        }
    }
}
