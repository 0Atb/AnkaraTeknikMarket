using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Sipari : AudiTableEntity, IBaseDomain
    {
        public Sipari()
        {
            SiparisDetays = new HashSet<SiparisDetay>();
            SiparisKampanyas = new HashSet<SiparisKampanya>();
        }

        public DateTime? SiparisTarihi { get; set; }
        public int? KullaniciId { get; set; }
        public decimal? ToplamSiparisTutari { get; set; }
        public int? Indirim { get; set; }

        public virtual Kullanici? Kullanici { get; set; }
        public virtual ICollection<SiparisDetay> SiparisDetays { get; set; }
        public virtual ICollection<SiparisKampanya> SiparisKampanyas { get; set; }
    }
}
