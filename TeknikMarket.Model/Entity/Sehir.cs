using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Sehir : AudiTableEntity, IBaseDomain
    {
        public Sehir()
        {
            Kullanicis = new HashSet<Kullanici>();
        }

        public string? SehirAdi { get; set; }

        public virtual ICollection<Kullanici> Kullanicis { get; set; }
    }
}
