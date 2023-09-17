using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Urun : AudiTableEntity, IBaseDomain
    {
        public Urun()
        {
            Sepets = new HashSet<Sepet>();
            SiparisDetays = new HashSet<SiparisDetay>();
            TaksitSeceneks = new HashSet<TaksitSecenek>();
            UrunFiyats = new HashSet<UrunFiyat>();
            UrunFotografs = new HashSet<UrunFotograf>();
            UrunResims = new HashSet<UrunResim>();
        }

        public string? UrunAdi { get; set; }
        public string? Aciklama { get; set; }
        public int? KategoriId { get; set; }
        public int? Stok { get; set; }

        public virtual Kategori? Kategori { get; set; }
        public virtual ICollection<Sepet> Sepets { get; set; }
        public virtual ICollection<SiparisDetay> SiparisDetays { get; set; }
        public virtual ICollection<TaksitSecenek> TaksitSeceneks { get; set; }
        public virtual ICollection<UrunFiyat> UrunFiyats { get; set; }
        public virtual ICollection<UrunFotograf> UrunFotografs { get; set; }
        public virtual ICollection<UrunResim> UrunResims { get; set; }
    }
}
