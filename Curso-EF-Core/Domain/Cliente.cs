using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Domain;

//[Table("Clientes")] //Configura o nome da tabela no banco de dados
public class Cliente
{
    //[Key] //Configura Id como chave primária de Cliente
    public int Id { get; set; }

    //[Required] //O campo não pode ser nulo
    public string Nome { get; set; }

   // [Column("Phone")] //Configura o nome da coluna na base de dados
    public string Telefone { get; set; }
    public string CEP { get; set; }
    public string Estado { get; set; }
    public string Cidade { get; set; }
    public string Email { get; set; }
}
