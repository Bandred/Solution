using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Models
{
    public class PropertyConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PropertyEntity> entityBuilder)
        {
            entityBuilder.ToTable("Properties");

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasQueryFilter(x => !x.Deleted);

            entityBuilder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entityBuilder.Property(x => x.Address).HasMaxLength(200).IsRequired();
            entityBuilder.Property(x => x.Price).HasPrecision(18,5).IsRequired();
            entityBuilder.Property(x => x.CodeInternal).HasMaxLength(200).IsRequired();
            entityBuilder.Property(x => x.Year).HasMaxLength(10).IsRequired();
            entityBuilder.Property(x => x.IdOwner).IsRequired();

            entityBuilder.HasOne(x => x.Owner).WithMany(x => x.Properties).HasForeignKey(x => x.IdOwner);
        }
    }
}
