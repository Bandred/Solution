using CrossCutting.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Domain.Entities.Models
{
    public class PropertyTraceConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PropertyTraceEntity> entityBuilder)
        {
            entityBuilder.ToTable("PropertyTraces");

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasQueryFilter(x => !x.Deleted);

            entityBuilder.Property(x => x.DateSale).IsRequired();
            entityBuilder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entityBuilder.Property(x => x.Value).HasPrecision(18, 5).IsRequired();
            entityBuilder.Property(x => x.Tax).HasPrecision(18, 5).IsRequired();
            entityBuilder.Property(x => x.IdProperty).IsRequired();

            entityBuilder.HasOne(x => x.Property).WithMany(x => x.PropertyTraces).HasForeignKey(x => x.IdProperty);
        }
    }
}
