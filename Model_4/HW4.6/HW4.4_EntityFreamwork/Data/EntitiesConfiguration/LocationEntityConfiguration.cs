using HW4._4_EntityFreamwork.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HW4._4_EntityFreamwork.Data.EntitiesConfiguration
{
    public class LocationEntityConfiguration : IEntityTypeConfiguration<LocationEntity>
    {
        public void Configure(EntityTypeBuilder<LocationEntity> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.LocationName).HasMaxLength(255);
        }
    }
}
