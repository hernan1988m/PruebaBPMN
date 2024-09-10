﻿using Api.Crud.Hcc.Models.DTOs.Respuestas;
using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Repositorio.Interfaces.Ordenes;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Crud.Hcc.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApiController : Controller
    {
        private readonly IOrden _orden;
        public ApiController(IOrden orden) 
        {
           _orden = orden;
        }

        [HttpGet("Ordenes")]
        [ProducesResponseType(typeof(AppRespuesta<List<MesaOrdenRespuesta>>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppRespuesta<List<MesaOrdenRespuesta>>>> Ordenes()
        {
            AppRespuesta<List<MesaOrdenRespuesta>> respuesta = new AppRespuesta<List<MesaOrdenRespuesta>>();
            try
            {  
                var listadoOrdenes = await _orden.Ordenes();

                if ( listadoOrdenes.EsError == true)
                {                   
                    respuesta.AppError(listadoOrdenes.Mensaje ?? "Error");
                    return Ok(respuesta);
                }

                respuesta.AppExitoso(listadoOrdenes.Datos, listadoOrdenes.Mensaje);
                
            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Ocurrió un problema al obtener las órdenes.");
               
            }
            return Ok(respuesta);
        }

        [HttpGet("Mesas")]
        [ProducesResponseType(typeof(AppRespuesta<DisponibilidadMesaRespuesta>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppRespuesta<DisponibilidadMesaRespuesta>>> Mesas()
        {
            AppRespuesta<DisponibilidadMesaRespuesta> respuesta = new AppRespuesta<DisponibilidadMesaRespuesta>();
            try
            {
                var mesasDisponiblesLugaresMesas = await _orden.Mesas();

                if (mesasDisponiblesLugaresMesas.EsError == true)
                {
                    respuesta.AppError(mesasDisponiblesLugaresMesas.Mensaje ?? "Error");
                    return Ok(respuesta);
                }

                respuesta.AppExitoso(mesasDisponiblesLugaresMesas.Datos, mesasDisponiblesLugaresMesas.Mensaje);
            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Ocurrió un problema al obtener las mesas.");
                
            }

            return Ok(respuesta);
        }

        [HttpPost("Alta/Orden")]
        [ProducesResponseType(typeof(AppRespuesta<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppRespuesta<bool>>> AltaOrden()
        {
            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Ocurrió un problema al dar de alta la orden.");
                return Ok(respuesta);
            }
        }

        [HttpPut("Actualiza/Orden/AgregaProducto")]
        [ProducesResponseType(typeof(AppRespuesta<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppRespuesta<bool>>> AgregaProductoOrden()
        {
            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Ocurrió un problema al agregar el producto a la orden.");
                return Ok(respuesta);
            }
        }

        [HttpPut("Actualiza/Orden/Estatus")]
        [ProducesResponseType(typeof(AppRespuesta<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppRespuesta<bool>>> EstatusOrden()
        {
            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Ocurrió un problema al modificar el estatus de la orden.");
                return Ok(respuesta);
            }
        }

        [HttpDelete("Elimina/Orden")]
        [ProducesResponseType(typeof(AppRespuesta<bool>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppRespuesta<bool>>> EliminaOrden()
        {
            AppRespuesta<bool> respuesta = new AppRespuesta<bool>();
            try
            {
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.AppError(ex, "Ocurrió un problema al eliminar la orden.");
                return Ok(respuesta);
            }
        }
    }
}
