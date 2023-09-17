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
    public class RolBs:IRolBS
    {
        private IRolRepository repo;
        public RolBs(IRolRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(Rol entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Rol Get(Expression<Func<Rol, bool>> fRolter, params string[] includelist)
        {
            return repo.Get(fRolter, includelist);
        }

        public List<Rol> GetAll(Expression<Func<Rol, bool>> fRolter, params string[] includelist)
        {
            return repo.GetAll(fRolter, includelist);
        }

        public Rol GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(Rol entity)
        {
            repo.Insert(entity);
        }

        public void Update(Rol entity)
        {
            repo.Update(entity);
        }
    }
}
