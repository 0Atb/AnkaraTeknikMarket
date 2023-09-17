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
    public class KampanyaTipiBs:IKampanyaTipiBS
    {
        private IKampanyaTipiRepository repo;
        public KampanyaTipiBs(IKampanyaTipiRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(KampanyaTipi entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public KampanyaTipi Get(Expression<Func<KampanyaTipi, bool>> fKampanyaTipiter, params string[] includelist)
        {
            return repo.Get(fKampanyaTipiter, includelist);
        }

        public List<KampanyaTipi> GetAll(Expression<Func<KampanyaTipi, bool>> fKampanyaTipiter, params string[] includelist)
        {
            return repo.GetAll(fKampanyaTipiter, includelist);
        }

        public KampanyaTipi GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(KampanyaTipi entity)
        {
            repo.Insert(entity);
        }

        public void Update(KampanyaTipi entity)
        {
            repo.Update(entity);
        }
    }
}
