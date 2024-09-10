using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Models.DTOs.Respuestas;
using Api.Crud.Hcc.Models.DTOs.Solicitudes;

namespace Api.Crud.Hcc.Repositorio.Interfaces.Ordenes.Consultas
{
    public interface IConsultaOrdenes
    {
        Task<AppRespuesta<List<MesaOrdenRespuesta>>> GetOrdenes();
        Task<AppRespuesta<DisponibilidadMesaRespuesta>> GetMesasDisponibles();
        Task<AppRespuesta<bool>> AltaOrden(AltaOrdenSolicitud orden);
        Task<AppRespuesta<bool>> ActualizaProductoOrden(ActualizaOrdenProductoSolicitud parametros);
        Task<AppRespuesta<bool>> ActualizarEstatusOrden(ActualizaEstatusOrdenSolicitud parametros);
    }
}
