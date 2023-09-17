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
    public class IlBS:IIlBS
    {
        private readonly IIlRepository _repo;

        public IlBS(IIlRepository repo)
        {
            _repo = repo;
        }

        public void Delete(Il entity)
        {
            _repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            _repo.Delete(Id);
        }

        public Il Get(Expression<Func<Il, bool>> filter, params string[] incluedelist)
        {
            return _repo.Get(filter, incluedelist);
        }

        public List<Il> GetAll(Expression<Func<Il, bool>> filter, params string[] incluedelist)
        {
            return _repo.GetAll(filter, incluedelist);
        }

        public Il GetById(int Id, params string[] incluedelist)
        {
            return _repo.GetById(Id, incluedelist);
        }

        public void Insert(Il entity)
        {
            _repo.Insert(entity);
        }

        public void Update(Il entity)
        {
            _repo.Update(entity);
        }
    }
}
