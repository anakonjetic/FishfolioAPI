using FishfolioAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishfolioAPI.DAL
{
    public class FishFamilyConfiguration : IEntityTypeConfiguration<FishFamilyCompatibility>
    {
        public void Configure(EntityTypeBuilder<FishFamilyCompatibility> builder)
        {
            builder.HasKey(x => new { x.ParentId, x.CompatibilityId });
            builder
                .HasOne(x => x.Parent)
                .WithMany(x => x.CompatibleWith)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction); 
        }
    }

    public class FishFamilyConfiguration2 : IEntityTypeConfiguration<FishFamilyIncompatibility>
    {
        public void Configure(EntityTypeBuilder<FishFamilyIncompatibility> builder)
        {
            builder.HasKey(x => new { x.ParentId, x.CompatibilityId });
            builder
                .HasOne(x => x.Parent)
                .WithMany(x => x.IncompatibleWith)
                .HasForeignKey(x => x.ParentId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
