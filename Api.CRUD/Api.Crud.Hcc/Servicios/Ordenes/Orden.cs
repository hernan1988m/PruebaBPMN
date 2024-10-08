﻿using Api.Crud.Hcc.Models.DTOs.Respuestas;
using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Models.DTOs.Solicitudes;
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


        public async Task<AppRespuesta<bool>> AltaOrden(AltaOrdenSolicitud orden)
        {

            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                var resultadoAlta = await _consultas.AltaOrden(orden);

                if (resultadoAlta.EsError == true)
                {
                    respuesta.AppError(resultadoAlta.Mensaje);
                    return respuesta;
                }

                respuesta.AppExitoso(resultadoAlta.Datos, resultadoAlta.Mensaje);

            }
            catch (Exception ex)
            {
                respuesta.AppError(ex.Message);
            }


            return respuesta;
        }

        public async Task<AppRespuesta<bool>> ActualizaOrdenProducto(ActualizaOrdenProductoSolicitud parametros)
        {

            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                var resultadoAltualizaProductoOrden = await _consultas.ActualizaProductoOrden(parametros);

                if (resultadoAltualizaProductoOrden.EsError == true)
                {
                    respuesta.AppError(resultadoAltualizaProductoOrden.Mensaje);
                    return respuesta;
                }

                respuesta.AppExitoso(resultadoAltualizaProductoOrden.Datos, resultadoAltualizaProductoOrden.Mensaje);

            }
            catch (Exception ex)
            {
                respuesta.AppError(ex.Message);
            }


            return respuesta;
        }

        public async Task<AppRespuesta<bool>> ActualizaEstatsOrden(ActualizaEstatusOrdenSolicitud parametros)
        {

            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                var resultadoAltualizaEstatusOrden = await _consultas.ActualizarEstatusOrden(parametros);

                if (resultadoAltualizaEstatusOrden.EsError == true)
                {
                    respuesta.AppError(resultadoAltualizaEstatusOrden.Mensaje);
                    return respuesta;
                }

                respuesta.AppExitoso(resultadoAltualizaEstatusOrden.Datos, resultadoAltualizaEstatusOrden.Mensaje);

            }
            catch (Exception ex)
            {
                respuesta.AppError(ex.Message);
            }


            return respuesta;
        }

        public async Task<AppRespuesta<bool>> EliminaOrden(int ordenId)
        {

            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                var resultadoEliminaOrden = await _consultas.EliminarOrden(ordenId);

                if (resultadoEliminaOrden.EsError == true)
                {
                    respuesta.AppError(resultadoEliminaOrden.Mensaje);
                    return respuesta;
                }

                respuesta.AppExitoso(resultadoEliminaOrden.Datos, resultadoEliminaOrden.Mensaje);

            }
            catch (Exception ex)
            {
                respuesta.AppError(ex.Message);
            }


            return respuesta;
        }
    }
}
