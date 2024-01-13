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
    public class PetEntityConfiguration : IEntityTypeConfiguration<PetEntity>
    {
        public void Configure(EntityTypeBuilder<PetEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(c => c.CategotyId).IsRequired();
            builder.Property(l => l.LocationId).IsRequired();
            builder.Property(b => b.BreedId).IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Pets)
                .HasForeignKey(p => p.CategotyId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Location)
                .WithMany(l => l.Pets)
                .HasForeignKey(p => p.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Breed)
                .WithMany(b => b.Pets)
                .HasForeignKey(p => p.BreedId) 
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(p => p.Name).HasMaxLength(255);
            builder.Property(p => p.Age);
        }
    }
}
