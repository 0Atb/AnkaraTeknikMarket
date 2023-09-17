using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Firma : AudiTableEntity, IBaseDomain
    {
        
        public int? KullaniciId { get; set; }
        public string? FirmaAdi { get; set; }
        public string? VergiNumarasi { get; set; }
        public string? VergiDairesi { get; set; }
        public string? TckimlikNo { get; set; }
        

        public virtual Kullanici? Kullanici { get; set; }
    }
}
