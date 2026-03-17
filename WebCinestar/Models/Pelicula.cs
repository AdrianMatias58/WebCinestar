namespace WebCinestar.Models
{
    public class Pelicula
    {
        public int id { get; set; }
        public string Titulo { get; set; }
        public string FechaEstreno { get; set; }
        public string Director { get; set; }
        public string Generos  { get; set; }
        public int ? idClasificacion { get; set; }
        public int ? idEstado { get; set; }
        public string Duracion { get; set; }
        public string Link { get; set; }
        public string Reparto { get; set; }
        public string Sinopsis { get; set; }
        
    }
}
