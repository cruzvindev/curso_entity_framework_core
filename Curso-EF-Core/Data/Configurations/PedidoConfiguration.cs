﻿using Curso_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedidos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.IniciadoEm).HasDefaultValueSql("CURRENT_TIMESTAMP()").ValueGeneratedOnAdd();
        builder.Property(p => p.Status).HasConversion<string>();
        builder.Property(p => p.TipoFrete).HasConversion<int>();
        builder.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

        builder.HasMany(p => p.Itens)
            .WithOne(p => p.Pedido)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
