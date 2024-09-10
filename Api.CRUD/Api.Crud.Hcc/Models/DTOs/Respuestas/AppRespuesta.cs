using static Api.Crud.Hcc.Repositorio.Interfaces.IAppRespuesta;
using System.Net;

namespace Api.Crud.Hcc.Models.DTOs.Respuestas
{
    public class AppRespuesta<T> : IAppRespuesta<T>
    {
        // Propiedad para almacenar el código de estado HTTP
        public HttpStatusCode Estatus { get; set; }

        // Propiedad para almacenar si hay un error
        public bool EsError { get; set; }

        // Propiedad para almacenar el mensaje
        public string Mensaje { get; set; }

        // Propiedad para almacenar el número de error
        public int Codigo { get; set; }

        // Propiedad para almacenar el objeto genérico
        public T Datos { get; set; }

        public void AppExitoso(T datos, string mensaje )
        {
            Estatus = HttpStatusCode.OK;
            EsError = false;
            Mensaje = mensaje;
            Datos = datos;
            Codigo = 1;
        }

        public void AppNoEncontrado(T datos, string mensaje)
        {
            Estatus = HttpStatusCode.NotFound;
            EsError = true;
            Mensaje = mensaje;
            Codigo = 1;
            Datos = datos;
        }

        public void AppError(string mensaje)
        {
            Estatus = HttpStatusCode.InternalServerError;
            EsError = true;
            Mensaje = mensaje;
            Codigo = -1;
            Datos = default(T);
        }

        public void AppError(Exception ex, string mensaje)
        {
            Estatus = HttpStatusCode.InternalServerError;
            EsError = true;
            Mensaje = ex.Message;
            Codigo = -1;
            Datos = default(T);

        }

        public void AppCreado(T datos, string mensaje)
        {
            Estatus = HttpStatusCode.Created;
            EsError = false;
            Mensaje = mensaje;
            Datos = datos;
            Codigo = 1;
        }

        public void AppSiContenido(string mensaje)
        {
            Estatus = HttpStatusCode.NoContent;
            EsError = true;
            Mensaje = mensaje;
            Codigo = 1;
            Datos = default(T);
        }

        public void AppNoAutorizado(string mensaje)
        {
            Estatus = HttpStatusCode.NoContent;
            EsError = true;
            Mensaje = mensaje;
            Codigo = -1;
            Datos = default(T);
        }
    }
}
