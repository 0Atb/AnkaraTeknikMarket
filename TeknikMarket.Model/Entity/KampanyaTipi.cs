using Core.Domain;
using System;
using System.Collections.Generic;

namespace TeknikMarket.Model.Entity
{
    public partial class KampanyaTipi : AudiTableEntity, IBaseDomain
    {
        public KampanyaTipi()
        {
            Kampanyas = new HashSet<Kampanya>();
        }

        public string? Tip { get; set; }

        public virtual ICollection<Kampanya> Kampanyas { get; set; }
    }
}
