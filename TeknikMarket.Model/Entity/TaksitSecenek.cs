using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class TaksitSecenek : AudiTableEntity, IBaseDomain
    {
        public int? BankaId { get; set; }
        public int? UrunId { get; set; }
        public int? TaksitSayisi { get; set; }
        public int? TaksitCizelgeId { get; set; }

        public virtual Banka? Banka { get; set; }
        public virtual Urun? Urun { get; set; }
    }
}
