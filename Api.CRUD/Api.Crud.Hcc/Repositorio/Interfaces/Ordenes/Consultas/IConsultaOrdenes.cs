using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Models.DTOs.Respuestas;

namespace Api.Crud.Hcc.Repositorio.Interfaces.Ordenes.Consultas
{
    public interface IConsultaOrdenes
    {
        Task<AppRespuesta<List<MesaOrdenRespuesta>>> GetOrdenes();
        Task<AppRespuesta<DisponibilidadMesaRespuesta>> GetMesasDisponibles();
    }
}
