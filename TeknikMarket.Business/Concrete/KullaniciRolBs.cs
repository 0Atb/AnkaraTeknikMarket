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
    public class KullaniciRolBs:IKullaniciRolBS
    {
        private IKullaniciRolRepository repo;
        public KullaniciRolBs(IKullaniciRolRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(KullaniciRol entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public KullaniciRol Get(Expression<Func<KullaniciRol, bool>> fKullaniciRolter, params string[] includelist)
        {
            return repo.Get(fKullaniciRolter, includelist);
        }

        public List<KullaniciRol> GetAll(Expression<Func<KullaniciRol, bool>> fKullaniciRolter, params string[] includelist)
        {
            return repo.GetAll(fKullaniciRolter, includelist);
        }

        public KullaniciRol GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(KullaniciRol entity)
        {
            repo.Insert(entity);
        }

        public void Update(KullaniciRol entity)
        {
            repo.Update(entity);
        }
    }
}
