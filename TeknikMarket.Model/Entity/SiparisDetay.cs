using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class SiparisDetay : AudiTableEntity, IBaseDomain
    {
        public int? SiparisId { get; set; }
        public int? UrunId { get; set; }
        public int? Adet { get; set; }
        public int? BirimFiyati { get; set; }
        public int? Indirim { get; set; }

        public virtual Sipari? Siparis { get; set; }
        public virtual Urun? Urun { get; set; }
    }
}
