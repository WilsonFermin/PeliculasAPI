namespace PeliculasAPI.DTOs
{
    public class PaginacionDTO
    {
        public int Pagina { get; set; } = 1;
        public int recordsPorPagina = 10;
        public readonly int CantidadMaximaPorPagina  = 50;


        public int RecordsPorPagina
        {
            get
            {
                return recordsPorPagina;
            }
            set
            {
                recordsPorPagina = (value > CantidadMaximaPorPagina) ? CantidadMaximaPorPagina : value;
            }
        }
    }
}
