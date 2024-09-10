using Api.Crud.Hcc.Models.DTOs.Respuestas;
using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Repositorio.Interfaces.Ordenes;
using Api.Crud.Hcc.Repositorio.Interfaces.Ordenes.Consultas;
using Microsoft.IdentityModel.Tokens;
using static Api.Crud.Hcc.Repositorio.Interfaces.IAppRespuesta;

namespace Api.Crud.Hcc.Servicios.Ordenes
{
    public class Orden: IOrden
    {
        private readonly IConsultaOrdenes _consultas;
        
        public Orden(IConsultaOrdenes consultas)
        {
           _consultas = consultas;
        }
        public async Task<AppRespuesta<List<MesaOrdenRespuesta>>> Ordenes()
        {            
              
            AppRespuesta<List<MesaOrdenRespuesta>> respuesta = new AppRespuesta<List<MesaOrdenRespuesta>>();
            try
            {
                var resultadoOdernes = await _consultas.GetOrdenes();

                if (resultadoOdernes.EsError == true)
                {
                    respuesta.AppError(resultadoOdernes.Mensaje);
                    return respuesta;
                }

                respuesta.AppExitoso(resultadoOdernes.Datos, resultadoOdernes.Mensaje);                
                
            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Error al procesar las ordenes");
            }
                

            return respuesta;
        }

        public async Task<AppRespuesta<DisponibilidadMesaRespuesta>> Mesas()
        {

            AppRespuesta<DisponibilidadMesaRespuesta> respuesta = new AppRespuesta<DisponibilidadMesaRespuesta>();
            try
            {
                var resultadoMesas = await _consultas.GetMesasDisponibles();

                if (resultadoMesas.EsError == true)
                {
                    respuesta.AppError(resultadoMesas.Mensaje);
                    return respuesta;
                }

                respuesta.AppExitoso(resultadoMesas.Datos, resultadoMesas.Mensaje);

            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Error al procesar las ordenes");
            }


            return respuesta;
        }
    }
}
