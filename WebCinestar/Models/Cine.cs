namespace WebCinestar.Models
{
    public class Cine
    {
        public int id { get; set; }
        public string RazonSocial { get; set; }
        public int Salas { get; set; }
        public string Direccion { get; set; }
        public string Telefonos { get; set; }
        public int? idDistrito { get; set; }
    }
}
