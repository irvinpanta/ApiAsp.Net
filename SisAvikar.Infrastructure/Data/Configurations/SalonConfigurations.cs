using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisAvikar.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAvikar.Infrastructure.Data.Configurations
{
    class SalonConfigurations : IEntityTypeConfiguration<Salones>
    {
        public void Configure(EntityTypeBuilder<Salones> builder)
        {
            builder.ToTable("Salones");
            builder.HasKey(e => e.Salon)
                .HasName("PK__Salones__49C0E33C4B6A6853");

            builder.HasIndex(e => e.Descripcion, "UQ__Salones__92C53B6C887620C2")
                .IsUnique();

            builder.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
