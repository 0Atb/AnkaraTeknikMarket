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
    public class BankaBS : IBankaBS
    {
        private readonly IBankaRepository _repo;

        public BankaBS(IBankaRepository repo)
        {
            _repo = repo;
        }

        public void Delete(Banka entity)
        {
            _repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public Banka Get(Expression<Func<Banka, bool>> filter, params string[] incluedelist)
        {
            return _repo.Get(filter, incluedelist);
        }

        public List<Banka> GetAll(Expression<Func<Banka, bool>> filter, params string[] incluedelist)
        {
            return _repo.GetAll(filter, incluedelist);
        }

        public Banka GetById(int Id, params string[] incluedelist)
        {
            return _repo.GetById(Id, incluedelist);
        }

        public void Insert(Banka entity)
        {
            _repo.Insert(entity);
        }

        public void Update(Banka entity)
        {
            _repo.Update(entity);
        }
    }
}
