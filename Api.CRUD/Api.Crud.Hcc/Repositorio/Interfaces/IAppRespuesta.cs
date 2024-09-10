namespace Api.Crud.Hcc.Repositorio.Interfaces
{
    public interface IAppRespuesta
    {
        public interface IAppRespuesta<T>
        {
            public void AppExitoso(T datos, string mensaje);

            public void AppNoEncontrado(T datos, string mensaje );

            public void AppError(string mensaje );

            public void AppError(Exception ex, string Mensaje);

            public void AppCreado(T datos, string mensaje);

            public void AppSiContenido(string mensaje);

            public void AppNoAutorizado(string mensaje);
        }
    }
}
