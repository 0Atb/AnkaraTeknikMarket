using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Sepet : AudiTableEntity, IBaseDomain
    {
        public int? UrunId { get; set; }
        public int? Adet { get; set; }
        public decimal? ToplamTutar { get; set; }

        public virtual Urun? Urun { get; set; }
    }
}
