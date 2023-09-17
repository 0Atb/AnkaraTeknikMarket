using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class StokBirim : AudiTableEntity, IBaseDomain
    {
        public string? BirimAdi { get; set; }
    }
}
