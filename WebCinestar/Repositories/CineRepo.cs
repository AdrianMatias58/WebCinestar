using NuGet.Protocol;
using WebCinestar.Database;
using WebCinestar.Models;

namespace WebCinestar.Repositories
{
    public class CineRepo
    {
        private readonly clsDB _clsDB;

        public CineRepo(IConfiguration configuration)
        {
            _clsDB = new clsDB(configuration, "CineStar");
        }
        public List<Cine> GetCines() {
            _clsDB.Sentencia("EXEC sp_getCines");
            string[][]? rows = _clsDB.getRegistros();

            List<Cine> lista = new List<Cine>();
            if (rows == null) return lista;

            foreach (string[] r in rows)
            {
                lista.Add(new Cine
                {
                    id = int.Parse(r[0]),
                    RazonSocial = r[1],
                    Salas = int.Parse(r[2]),
                    idDistrito = string.IsNullOrEmpty(r[3]) ? null : int.Parse(r[3]),
                    Direccion = r[4],
                    Telefonos = r[5],
                    Distrito = r[6]   
                });
            }
            return lista;
        }
        public Cine GetCine(int id) {
            _clsDB.Sentencia($"EXEC sp_getCine {id}");
            string[]? r = _clsDB.getRegistro();
            if (r == null) return null;
            return new Cine
            {
                id = int.Parse(r[0]),
                RazonSocial = r[1],
                Salas = int.Parse(r[2]),
                idDistrito = string.IsNullOrEmpty(r[3]) ? null : int.Parse(r[3]),
                Direccion = r[4],
                Telefonos = r[5],
                Distrito = r[6]
            };
        }

        public List<CineTarifa> GetTarifas(int idCine)
        {
            _clsDB.Sentencia($"EXEC sp_getCineTarifas {idCine}");
            string[][]? rows = _clsDB.getRegistros();
            List<CineTarifa> lista = new List<CineTarifa>();
            if (rows == null) return lista;

            foreach (string[] r in rows)
            {
                lista.Add(new CineTarifa
                {
                    DiasSemana = r[0],
                    Precio = r[1]
                });
            }
            return lista;
        }
        public List<CinePelicula> GetPeliculas(int idCine)
        {
            _clsDB.Sentencia($"EXEC sp_getCinePeliculas {idCine}");
            string[][]? rows = _clsDB.getRegistros();

            List<CinePelicula> lista = new List<CinePelicula>();
            if (rows == null) return lista;

            foreach (string[] r in rows)
            {
                lista.Add(new CinePelicula
                {
                    Titulo = r[0],
                    Horarios = r[1]
                });
            }
            return lista;
        }

    }
}
