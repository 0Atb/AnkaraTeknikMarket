using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class SiparisKampanya : AudiTableEntity, IBaseDomain
    {
        public int? SiparisId { get; set; }
        public int? KampanyaId { get; set; }

        public virtual Kampanya? Kampanya { get; set; }
        public virtual Sipari? Siparis { get; set; }
    }
}
