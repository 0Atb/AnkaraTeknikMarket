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
    public class KullaniciBs:IKullaniciBS
    {
        private readonly IKullaniciRepository _repo;

        public KullaniciBs(IKullaniciRepository repo)
        {
            _repo = repo;
        }

        public void Delete(Kullanici entity)
        {
            _repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> filter, params string[] incluedelist)
        {
            return _repo.Get(filter, incluedelist);
        }

        public List<Kullanici> GetAll(Expression<Func<Kullanici, bool>> filter, params string[] incluedelist)
        {
            return _repo.GetAll(filter, incluedelist);
        }

        public Kullanici GetById(int Id, params string[] incluedelist)
        {
            return _repo.GetById(Id, incluedelist);
        }

        public void Insert(Kullanici entity)
        {
            _repo.Insert(entity);
        }

        public void Update(Kullanici entity)
        {
            _repo.Update(entity);
        }
    }
}
