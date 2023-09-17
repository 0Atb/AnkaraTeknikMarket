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
    public class SiparisDetayBs:ISiparisDetayBS
    {
        private ISiparisDetayRepository repo;
        public SiparisDetayBs(ISiparisDetayRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(SiparisDetay entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public SiparisDetay Get(Expression<Func<SiparisDetay, bool>> fSiparisDetayter, params string[] includelist)
        {
            return repo.Get(fSiparisDetayter, includelist);
        }

        public List<SiparisDetay> GetAll(Expression<Func<SiparisDetay, bool>> fSiparisDetayter, params string[] includelist)
        {
            return repo.GetAll(fSiparisDetayter, includelist);
        }

        public SiparisDetay GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(SiparisDetay entity)
        {
            repo.Insert(entity);
        }

        public void Update(SiparisDetay entity)
        {
            repo.Update(entity);
        }
    }
}
