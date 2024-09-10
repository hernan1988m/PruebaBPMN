using Api.Crud.Hcc.Models.Context;
using Api.Crud.Hcc.Models.DTOs.Respuestas;
using Api.Crud.Hcc.Models.DTOs.Respuestas.Ordenes;
using Api.Crud.Hcc.Models.Entidades;
using Api.Crud.Hcc.Repositorio.Interfaces.Ordenes.Consultas;
using Microsoft.EntityFrameworkCore;

namespace Api.Crud.Hcc.Servicios.Ordenes.Consultas
{
    public class ConsultaOrdenes : IConsultaOrdenes
    {
        private readonly ApiCrudContext _dbContexto;

        public ConsultaOrdenes(ApiCrudContext dbContexto) 
        { 
            _dbContexto = dbContexto;
        }

        public async Task<AppRespuesta<List<MesaOrdenRespuesta>>> GetOrdenes()
        {
            AppRespuesta<List<MesaOrdenRespuesta>> respuesta = new AppRespuesta<List<MesaOrdenRespuesta>>();
            try
            {
                var resultado =await _dbContexto.TbHccOrdenes
                    .Join(_dbContexto.TbHccMesas,
                        orden => orden.MesId,
                        mesa => mesa.MesId,
                        (orden, mesa) => new
                        {
                            MesaId = mesa.MesId,
                            NumeroMesa = mesa.MesLugares,
                            OrdenId = orden.OrdId
                        })
                    .GroupBy(x => new { x.MesaId, x.NumeroMesa })
                    .Select(grupo => new MesaOrdenRespuesta
                    {
                        MesaId = grupo.Key.MesaId,
                        NumeroMesa = grupo.Key.NumeroMesa,
                        TotalOrdenes = grupo.Count()
                    })
                    .ToListAsync();

                respuesta.AppExitoso(resultado,"Listado de las ordenes");
            }
            catch (Exception ex)
            {
                respuesta.AppError("Ocurrió un error al obtener de los registros las ordenes ");
            }

            return respuesta;
        }

        public async Task<AppRespuesta<DisponibilidadMesaRespuesta>> GetMesasDisponibles()
        {
            AppRespuesta<DisponibilidadMesaRespuesta> respuesta = new AppRespuesta<DisponibilidadMesaRespuesta>();
            try
            {
                var totalMesasDisponibles = await _dbContexto.TbHccMesas
                    .Where(m => m.MesDisponible == 1)
                    .CountAsync(); // Número total de mesas disponibles

                var lugaresPorMesa = await _dbContexto.TbHccMesas
                    .Where(m => m.MesDisponible == 1)
                    .Select(m => new
                    {
                        MesaId = m.MesId,          // ID de la mesa
                        NumeroLugares = m.MesLugares // Número de lugares
                    })
                    .ToListAsync(); // Lista con la cantidad de lugares por mesa
                
                var lugares = new List<LugaresMesa>();

                foreach(var lugar in lugaresPorMesa)
                {
                    lugares.Add(new LugaresMesa { 
                        MesaId=lugar.MesaId,
                        NumeroLugares=lugar.NumeroLugares
                    });
                }


                respuesta.AppExitoso(new DisponibilidadMesaRespuesta
                {
                    TotalMesasDisponibles = totalMesasDisponibles,
                    LugaresMesas = lugares

                }, "Disponibilidad de mesas y lugares");
            }
            catch (Exception ex)
            {
                respuesta.AppError("Ocurrió un error al obtener las mesas disponibles.");
            }

            return respuesta;
        }
    }
}
