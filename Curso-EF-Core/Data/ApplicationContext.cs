
using Curso_EF_Core.Data.Configurations;
using Curso_EF_Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Data;

public class ApplicationContext : DbContext
{
   // private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());

    //Primeira forma de gerar o modelo de BD a partir de uma classe é expondo ela em um contexto DbSet, desse modo ela e as suas classes dependentes e as
    //as classes dependentes(propriedades de navegação) dela serão geradas no banco 
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Cliente> Clientes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
           // .UseLoggerFactory(_logger)
            .EnableSensitiveDataLogging()
            .UseMySql("Server=localhost;Database=curso-ef-core;User=root;Password=mysql1234;",
            new MySqlServerVersion(new Version(8, 0, 36)));
    }

    //Segunda forma é configurar manualmente as classes, seus atributos e seus relacionamentos através  da sobrescrita do método OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Esse método encontra e aplica automaticamente todas as configurações de entidade encontradas no assembly especificado.
        //No caso ele aplica todas as configurações de entidade definidas em classes que implementam a interface IEntityTypeConfiguration<T> e que estão
        //localizadas no mesmo assembly que a classe ApplicationContext.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}
