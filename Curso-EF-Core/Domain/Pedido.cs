﻿using Curso_EF_Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso_EF_Core.Domain;

public class Pedido
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; }
    public DateTime IniciadoEm {  get; set; }
    public DateTime FinalizadoEm { get; set; }
    public TipoFrete TipoFrete { get; set; }
    public StatusPedido Status { get; set; }  
    public string Observacao { get; set; }
    public ICollection<PedidoItem> Itens { get; set; }
}
