using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Models
{
    public class PropertyImageConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<PropertyImageEntity> entityBuilder)
        {
            entityBuilder.ToTable("PropertyImages");

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasQueryFilter(x => !x.Deleted);

            entityBuilder.Property(x => x.IdProperty).IsRequired();
            entityBuilder.Property(x => x.File).IsRequired();
            entityBuilder.Property(x => x.Enabled).IsRequired();

            entityBuilder.HasOne(x => x.Property).WithMany(x => x.PropertyImages).HasForeignKey(x => x.IdProperty);
        }
    }
}
