using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class UrunResim : AudiTableEntity, IBaseDomain
    {
        public int? UrunId { get; set; }
        public string? ResimYolu { get; set; }
        public byte[]? Resim { get; set; }

        public virtual Urun? Urun { get; set; }
    }
}
