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
    public class KampanyaBs: IKampanyaBS
    {
        private IKampanyaRepository repo;
        public KampanyaBs(IKampanyaRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(Kampanya entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public Kampanya Get(Expression<Func<Kampanya, bool>> fKampanyater, params string[] includelist)
        {
            return repo.Get(fKampanyater, includelist);
        }

        public List<Kampanya> GetAll(Expression<Func<Kampanya, bool>> fKampanyater, params string[] includelist)
        {
            return repo.GetAll(fKampanyater, includelist);
        }

        public Kampanya GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(Kampanya entity)
        {
            repo.Insert(entity);
        }

        public void Update(Kampanya entity)
        {
            repo.Update(entity);
        }
    }
}
