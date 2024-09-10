using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Models.DTOs.Respuestas;

namespace Api.Crud.Hcc.Repositorio.Interfaces.Ordenes
{
    public interface IOrden
    {
        Task<AppRespuesta<List<MesaOrdenRespuesta>>> Ordenes();
        Task<AppRespuesta<DisponibilidadMesaRespuesta>> Mesas();
    }
}
