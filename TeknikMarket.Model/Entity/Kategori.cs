using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Kategori : AudiTableEntity, IBaseDomain
    {
        public Kategori()
        {
            InverseUstKategori = new HashSet<Kategori>();
            Uruns = new HashSet<Urun>();
        }

        public string? KategoriAdi { get; set; }
        public int? UstKategoriId { get; set; }
        public string? KategoriGorunum { get; set; }
        public int? Sira { get; set; }

        public virtual Kategori? UstKategori { get; set; }
        public virtual ICollection<Kategori> InverseUstKategori { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
