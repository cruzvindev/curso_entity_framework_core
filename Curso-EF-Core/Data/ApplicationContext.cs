
using Curso_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Data;

public class ApplicationContext : DbContext
{
    //Primeira forma de gerar o modelo de BD a partir de uma classe é expondo ela em um contexto DbSet, desse modo ela e as suas classes dependentes e as
    //as classes dependentes(propriedades de navegação) dela serão geradas no banco 
    //public DbSet<Pedido> Pedidos { get; set; }  
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql("Server=localhost;Database=curso-ef-core;User=root;Password=mysql1234;",
            new MySqlServerVersion(new Version(8, 0, 36)));
    }

    //Segunda forma é configurar manualmente as classes, seus atributos e seus relacionamentos através  da sobrescrita do método OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(p =>
        {
            p.ToTable("Clientes");
            p.HasKey(p => p.Id); //configurando a chave primária
            p.Property(p => p.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            p.Property(p => p.Telefone).HasColumnType("CHAR(11)");
            p.Property(p => p.CEP).HasColumnType("CHAR(8)").IsRequired();
            p.Property(p => p.Estado).HasColumnType("CHAR(2)").IsRequired();
            p.Property(p => p.Cidade).HasMaxLength(60).IsRequired(); //pela propriedade ser uma string o EF já sabe que ela deve ser VARCHAR

            p.HasIndex(i => i.Telefone).HasName("idx_cliente_telefone"); //criando um índice para o campo telefone
        });

        modelBuilder.Entity<Produto>(p =>
        {
            p.ToTable("Produtos");
            p.HasKey(p => p.Id);
            p.Property(p => p.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            p.Property(p => p.Descricao).HasColumnType("VARCHAR(60)");
            p.Property(p => p.Valor).IsRequired();
            p.Property(p => p.TipoProduto).HasConversion<string>();//informa que o enum deve ser gravado como string no BD
        });

        modelBuilder.Entity<Pedido>(p =>
        {
            p.ToTable("Pedidos");
            p.HasKey(p => p.Id);
            p.Property(p => p.IniciadoEm).HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            p.Property(p => p.Status).HasConversion<string>();
            p.Property(p => p.TipoFrete).HasConversion<int>();//informa que o enum deve ser gravado como int no BD
            p.Property(p => p.Observacao).HasColumnType("VARCHAR(512)");

            p.HasMany(p => p.Itens) //Define que temos muitos itens para um pedido 
                .WithOne(p => p.Pedido)
                .OnDelete(DeleteBehavior.Cascade); //Quando um pedido for deletado os seus itens associados também serão excluidos
        });

        modelBuilder.Entity<PedidoItem>(p =>
        {
            p.ToTable("PedidoItens");
            p.HasKey(p => p.Id);
            p.Property(p => p.Quantidade).HasDefaultValue(1).IsRequired(); //Se não for informada uma quantidade o valor padrão será 1
            p.Property(p => p.Valor).IsRequired();
            p.Property(p => p.Desconto).IsRequired();
        });
    }
}
