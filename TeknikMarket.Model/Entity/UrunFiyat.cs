using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class UrunFiyat : AudiTableEntity, IBaseDomain
    {
        public int? UrunId { get; set; }
        public string? Baslik { get; set; }
        public string? Aciklama { get; set; }
        public decimal? Fiyat { get; set; }

        public virtual Urun? Urun { get; set; }
    }
}
