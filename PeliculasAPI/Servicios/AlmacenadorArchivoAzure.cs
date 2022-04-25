namespace PeliculasAPI.Servicios
{
    public class AlmacenadorArchivoAzure : IAlmacenadorArchivos
    {
        public Task BorrarArchivo(string ruta, string contenedor)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditarArchivo(byte[] contenido, string extension, 
            string contenedor, string ruta, string contentType)
        {
            throw new NotImplementedException();
        }

        public Task<string> GuardarArchivo(byte[] contenido, string extension, 
            string contenedor, string contetType)
        {
            throw new NotImplementedException();
        }
    }//Esta clase seria para subir las imagenes a azure
}
