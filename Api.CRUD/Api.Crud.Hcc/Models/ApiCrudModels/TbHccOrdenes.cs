using System;
using System.Collections.Generic;

namespace Api.Crud.Hcc.Models.ApiCrudModels;

public partial class TbHccOrdenes
{
    public int OrdId { get; set; }

    public int MesId { get; set; }

    public int CatordId { get; set; }

    public DateTime OrdFechaInicio { get; set; }

    public byte OrdEstatus { get; set; }

    public virtual TbHccCatEstatusOrden Catord { get; set; } = null!;

    public virtual TbHccMesas Mes { get; set; } = null!;

    public virtual ICollection<TbHccOrdenesDetalle> TbHccOrdenesDetalle { get; set; } = new List<TbHccOrdenesDetalle>();
}
