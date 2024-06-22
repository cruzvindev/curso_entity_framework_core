﻿using Curso_EF_Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Domain;

public class Produto
{
    public int Id { get; set; } 
    public string CodigoBarras { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public TipoProduto TipoProduto { get; set; }
    public bool Ativo {  get; set; }
}
