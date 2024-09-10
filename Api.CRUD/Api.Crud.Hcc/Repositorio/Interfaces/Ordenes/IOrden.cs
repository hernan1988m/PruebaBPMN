using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Models.DTOs.Respuestas;
using Api.Crud.Hcc.Servicios.Ordenes;
using Api.Crud.Hcc.Models.DTOs.Solicitudes;

namespace Api.Crud.Hcc.Repositorio.Interfaces.Ordenes
{
    public interface IOrden
    {
        Task<AppRespuesta<List<MesaOrdenRespuesta>>> Ordenes();
        Task<AppRespuesta<DisponibilidadMesaRespuesta>> Mesas();
        Task<AppRespuesta<bool>> AltaOrden(AltaOrdenSolicitud orden);
        Task<AppRespuesta<bool>> ActualizaOrdenProducto(ActualizaOrdenProductoSolicitud parametros);
    }
}
