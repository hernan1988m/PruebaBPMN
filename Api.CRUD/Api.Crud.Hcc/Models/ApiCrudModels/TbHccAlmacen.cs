using System;
using System.Collections.Generic;

namespace Api.Crud.Hcc.Models.ApiCrudModels;

public partial class TbHccAlmacen
{
    public int AlmId { get; set; }

    public int AlmCantidad { get; set; }

    public DateTime AlmFechaActualizacion { get; set; }

    public byte AlmEstatus { get; set; }

    public virtual ICollection<TbHccProductos> TbHccProductos { get; set; } = new List<TbHccProductos>();
}
