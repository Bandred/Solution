using CrossCutting.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public class PropertyTraceEntity : BaseEntity
    {
        public DateTime DateSale { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Tax { get; set; }
        public Guid IdProperty { get; set; }

        public virtual PropertyEntity Property { get; set; }
    }
}
