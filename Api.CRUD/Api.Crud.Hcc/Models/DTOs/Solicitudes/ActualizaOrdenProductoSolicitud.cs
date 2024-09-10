namespace Api.Crud.Hcc.Models.DTOs.Solicitudes
{
    public class ActualizaOrdenProductoSolicitud
    {
        public int ordenId { get; set; }    
        public int productoId { get; set; }
        public decimal cantidad { get; set; }
    }
}
