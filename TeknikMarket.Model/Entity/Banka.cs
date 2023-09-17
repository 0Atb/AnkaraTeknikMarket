using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Banka:AudiTableEntity,IBaseDomain
    {
        public Banka()
        {
            TaksitSeceneks = new HashSet<TaksitSecenek>();
        }

        
        public string? BankaAdi { get; set; }
        public string? BankaIcon { get; set; }
        

        public virtual ICollection<TaksitSecenek> TaksitSeceneks { get; set; }
    }
}
