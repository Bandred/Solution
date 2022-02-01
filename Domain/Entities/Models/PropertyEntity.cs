using CrossCutting.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public class PropertyEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Price { get; set; }
        public string CodeInternal { get; set; }
        public string Year { get; set; }
        public Guid IdOwner { get; set; }

        public virtual OwnerEntity Owner { get; set; }
        public virtual IList<PropertyImageEntity> PropertyImages { get; set; }
        public virtual IList<PropertyTraceEntity> PropertyTraces { get; set; }
    }
}
