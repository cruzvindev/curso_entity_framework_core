using Curso_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produtos");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
        builder.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
        builder.Property(p => p.Valor).IsRequired();
        builder.Property(p => p.TipoProduto).HasConversion<string>();//informa que o enum deve ser gravado como string no BD
    }
}
