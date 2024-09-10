using System;
using System.Collections.Generic;

namespace Api.Crud.Hcc.Models.ApiCrudModels;

public partial class TbHccProductos
{
    public int ProId { get; set; }

    public int AlmId { get; set; }

    public string ProNombre { get; set; } = null!;

    public string ProDescripcion { get; set; } = null!;

    public decimal ProPrecio { get; set; }

    public byte ProEstatus { get; set; }

    public virtual TbHccAlmacen Alm { get; set; } = null!;

    public virtual ICollection<TbHccOrdenesDetalle> TbHccOrdenesDetalle { get; set; } = new List<TbHccOrdenesDetalle>();
}
