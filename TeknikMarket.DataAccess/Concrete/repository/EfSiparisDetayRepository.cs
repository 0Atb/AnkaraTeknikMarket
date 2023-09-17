using Core.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.DataAccess.Abstract;
using TeknikMarket.Model.Entity;

namespace TeknikMarket.DataAccess.Concrete.repository
{
    public class EfSiparisDetayRepository : EfRepositoryBase<SiparisDetay, TeknikMarketDBContext>, ISiparisDetayRepository
    {
    }
}
