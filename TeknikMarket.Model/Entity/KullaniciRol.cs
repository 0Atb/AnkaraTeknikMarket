using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class KullaniciRol : AudiTableEntity, IBaseDomain
    {
        public int? KullanıcıId { get; set; }
        public int? RolId { get; set; }

        public virtual Kullanici? Kullanıcı { get; set; }
        public virtual Rol? Rol { get; set; }
    }
}
