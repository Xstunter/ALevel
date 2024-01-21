using HW4._4_EntityFreamwork.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4._4_EntityFreamwork.Data.EntitiesConfiguration
{
    public class BreedEntityConfiguration : IEntityTypeConfiguration<BreedEntity>
    {
        public void Configure(EntityTypeBuilder<BreedEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(c => c.CategoryId).IsRequired();

            builder.HasOne(b => b.Category)
                .WithMany(c => c.Breeds)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(b => b.BreedName).HasMaxLength(255);
        }
    }
}
