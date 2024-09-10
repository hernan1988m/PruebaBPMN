using Api.Crud.Hcc.Models.Entidades;

namespace Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes
{
    public class DisponibilidadMesaRespuesta
    {
        public int TotalMesasDisponibles { get; set; }
        public List<LugaresMesa> LugaresMesas { get; set; }
    }
}
