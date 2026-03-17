using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace WebCinestar.Models
{
    public class CinePelicula
    {
        public int idCine {  get; set; }
        public int idPelicula {  get; set; }
        public int Sala { get; set; }
        public string Horarios { get; set; }
    }
}
