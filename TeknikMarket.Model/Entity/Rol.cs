using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class Rol : AudiTableEntity, IBaseDomain
    {
        public Rol()
        {
            KullaniciRols = new HashSet<KullaniciRol>();
            YoneticiRols = new HashSet<YoneticiRol>();
        }

        public string? RolAdi { get; set; }

        public virtual ICollection<KullaniciRol> KullaniciRols { get; set; }
        public virtual ICollection<YoneticiRol> YoneticiRols { get; set; }
    }
}
