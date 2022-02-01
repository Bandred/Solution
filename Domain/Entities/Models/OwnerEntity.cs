using CrossCutting.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Entities.Models
{
    public class OwnerEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public DateTime Birthday { get; set; }

        public virtual IList<PropertyEntity> Properties { get; set; }
    }
}
