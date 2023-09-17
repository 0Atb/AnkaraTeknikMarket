using Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Data.Abstract
{
    public interface IRepository<Tentity>
        where Tentity : AudiTableEntity, IBaseDomain, new()
    {
        List<Tentity> GetAll(Expression<Func<Tentity, bool>> filter, params string[] includelist);
        Tentity Get(Expression<Func<Tentity, bool>> filter, params string[] includelist);
        Tentity GetById(int id,params string[] includelist);
        void Insert(Tentity entity);
        void Update(Tentity entity);
        void Delete(Tentity entity);
        void Delete(int id);
    }
}
