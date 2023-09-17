using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class YoneticiRol : AudiTableEntity, IBaseDomain
    {
        public int? YoneticiId { get; set; }
        public int? RolId { get; set; }

        public virtual Rol? Rol { get; set; }
        public virtual Yonetici? Yonetici { get; set; }
    }
}
