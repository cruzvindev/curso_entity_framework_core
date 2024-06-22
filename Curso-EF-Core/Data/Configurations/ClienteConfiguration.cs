using Curso_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente> //Essa interface foi introduzida no EF Core 2.0
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("Clientes");
        builder.HasKey(p => p.Id); //configurando a chave primária
        builder.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
        builder.Property(p => p.Telefone).HasColumnType("CHAR(11)");
        builder.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
        builder.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
        builder.Property(p => p.Cidade).HasMaxLength(60).IsRequired(); //pela propriedade ser uma string o EF já sabe que ela deve ser VARCHAR

        builder.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone"); //criando um índice para o campo telefone
    }
}
