using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Marka : AudiTableEntity, IBaseDomain
    {
        public string? MarkaAdi { get; set; }
        public string? Aciklama { get; set; }
        public string? FirmaResmi { get; set; }
    }
}
