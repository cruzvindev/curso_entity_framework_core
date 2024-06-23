using Curso_EF_Core.Domain;
using Curso_EF_Core.ValueObjects;
using Microsoft.EntityFrameworkCore;
namespace Curso_EF_Core;

public class Program
{
    static void Main(string[] args)
    {
        InserirDados();
    }

    private static void InserirDados()
    {
        var produto = new Produto
        {
            Descricao = "Produto Teste",
            CodigoBarras = "1234567891231",
            Valor = 10m,
            TipoProduto = TipoProduto.MercadoriaParaRevenda,
            Ativo = true
        };

        using var db = new Data.ApplicationContext();

        //db.Produtos.Add(produto);
        //db.Set<Produto>().Add(produto);
        //db.Entry(produto).State = EntityState.Added;
        db.Add(produto);

        var registros = db.SaveChanges(); //Salva de fato os registros
        Console.WriteLine($"Total Registros:  {registros}");
    }
}
