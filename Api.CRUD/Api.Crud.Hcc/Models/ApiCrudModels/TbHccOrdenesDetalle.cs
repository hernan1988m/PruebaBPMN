using System;
using System.Collections.Generic;

namespace Api.Crud.Hcc.Models.ApiCrudModels;

public partial class TbHccOrdenesDetalle
{
    public int OrddetId { get; set; }

    public int OrdId { get; set; }

    public int ProId { get; set; }

    public decimal OrddetCantidad { get; set; }

    public byte OrddetEstatus { get; set; }

    public virtual TbHccOrdenes Ord { get; set; } = null!;

    public virtual TbHccProductos Pro { get; set; } = null!;
}
