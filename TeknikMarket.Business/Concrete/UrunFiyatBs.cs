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
    public class UrunFiyatBs:IUrunFiyatBS
    {
        private IUrunFiyatRepository repo;
        public UrunFiyatBs(IUrunFiyatRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(UrunFiyat entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public UrunFiyat Get(Expression<Func<UrunFiyat, bool>> fUrunFiyatter, params string[] includelist)
        {
            return repo.Get(fUrunFiyatter, includelist);
        }

        public List<UrunFiyat> GetAll(Expression<Func<UrunFiyat, bool>> fUrunFiyatter, params string[] includelist)
        {
            return repo.GetAll(fUrunFiyatter, includelist);
        }

        public UrunFiyat GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(UrunFiyat entity)
        {
            repo.Insert(entity);
        }

        public void Update(UrunFiyat entity)
        {
            repo.Update(entity);
        }
    }
}
