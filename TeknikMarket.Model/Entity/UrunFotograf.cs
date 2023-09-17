using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class UrunFotograf : AudiTableEntity, IBaseDomain
    {
        public int? UrunId { get; set; }
        public string? FotografAdresi { get; set; }

        public virtual Urun? Urun { get; set; }
    }
}
