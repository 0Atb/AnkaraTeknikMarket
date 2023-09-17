using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Kampanya:AudiTableEntity,IBaseDomain
    {
        public Kampanya()
        {
            SiparisKampanyas = new HashSet<SiparisKampanya>();
        }

        public string? Baslik { get; set; }
        public string? Aciklama { get; set; }
        public int? KampanyaTipiId { get; set; }
        public decimal? Deger { get; set; }
        public bool? TekilKampanya { get; set; }

        public virtual KampanyaTipi? KampanyaTipi { get; set; }
        public virtual ICollection<SiparisKampanya> SiparisKampanyas { get; set; }
    }
}
