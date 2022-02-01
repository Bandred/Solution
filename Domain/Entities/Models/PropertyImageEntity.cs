using CrossCutting.Entities;
using System;

namespace Domain.Entities.Models
{
    public class PropertyImageEntity : BaseEntity
    {
        public Guid IdProperty { get; set; }
        public byte[] File { get; set; }
        public bool Enabled { get; set; }

        public virtual PropertyEntity Property { get; set; }
    }
}
