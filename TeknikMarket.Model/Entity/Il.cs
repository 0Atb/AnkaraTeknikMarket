using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Il : AudiTableEntity, IBaseDomain
    {
        public Il()
        {
            Kullanicis = new HashSet<Kullanici>();
        }

        public string? IlAdi { get; set; }
        public int? PlakaKodu { get; set; }

        public virtual ICollection<Kullanici> Kullanicis { get; set; }
    }
}
