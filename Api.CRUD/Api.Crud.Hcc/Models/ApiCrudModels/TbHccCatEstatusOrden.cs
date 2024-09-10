using System;
using System.Collections.Generic;

namespace Api.Crud.Hcc.Models.ApiCrudModels;

public partial class TbHccCatEstatusOrden
{
    public int CatordId { get; set; }

    public string CatordNombre { get; set; } = null!;

    public byte CatordEstatus { get; set; }

    public virtual ICollection<TbHccOrdenes> TbHccOrdenes { get; set; } = new List<TbHccOrdenes>();
}
