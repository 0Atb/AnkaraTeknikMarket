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
    public class SiparisKampanyaBs:ISiparisKampanyaBS
    {
        private ISiparisKampanyaRepository repo;
        public SiparisKampanyaBs(ISiparisKampanyaRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(SiparisKampanya entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public SiparisKampanya Get(Expression<Func<SiparisKampanya, bool>> filter, params string[] includelist)
        {
            return repo.Get(filter, includelist);
        }

        public List<SiparisKampanya> GetAll(Expression<Func<SiparisKampanya, bool>> filter, params string[] includelist)
        {
            return repo.GetAll(filter, includelist);
        }

        public SiparisKampanya GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(SiparisKampanya entity)
        {
            repo.Insert(entity);
        }

        public void Update(SiparisKampanya entity)
        {
            repo.Update(entity);
        }
    }
}
