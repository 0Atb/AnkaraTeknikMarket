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
    public class StokBirimBs:IStokBirimBS
    {
        private IStokBirimRepository repo;
        public StokBirimBs(IStokBirimRepository _repo)
        {
            repo = _repo;
        }
        public void Delete(StokBirim entity)
        {
            repo.Delete(entity);
        }

        public void Delete(int Id)
        {
            repo.Delete(Id);
        }

        public StokBirim Get(Expression<Func<StokBirim, bool>> fStokBirimter, params string[] includelist)
        {
            return repo.Get(fStokBirimter, includelist);
        }

        public List<StokBirim> GetAll(Expression<Func<StokBirim, bool>> fStokBirimter, params string[] includelist)
        {
            return repo.GetAll(fStokBirimter, includelist);
        }

        public StokBirim GetById(int Id, params string[] includelist)
        {
            return repo.GetById(Id, includelist);
        }

        public void Insert(StokBirim entity)
        {
            repo.Insert(entity);
        }

        public void Update(StokBirim entity)
        {
            repo.Update(entity);
        }
    }
}
