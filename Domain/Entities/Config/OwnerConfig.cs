using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Models
{
    public class OwnerConfig
    {
        public static void SetEntityBuilder(EntityTypeBuilder<OwnerEntity> entityBuilder)
        {
            entityBuilder.ToTable("Owners");

            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Id).IsRequired();

            entityBuilder.HasQueryFilter(x => !x.Deleted);

            entityBuilder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            entityBuilder.Property(x => x.Address).HasMaxLength(200).IsRequired();
            entityBuilder.Property(x => x.Photo);
            entityBuilder.Property(x => x.Birthday);
        }
    }
}
