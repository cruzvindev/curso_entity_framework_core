using Curso_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Data.Configurations;

public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.ToTable("PedidoItens");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired(); //Se não for informada uma quantidade o valor padrão será 1
        builder.Property(p => p.Valor).IsRequired();
        builder.Property(p => p.Desconto).IsRequired();
    }
}
