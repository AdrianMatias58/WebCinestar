using System.Collections;
using WebCinestar.Database;
using WebCinestar.Models;

namespace WebCinestar.Repositories
{
    public class PeliculaRepo
    {
        private readonly clsDB _clsDB;

        public PeliculaRepo (IConfiguration configuration)
        {
            _clsDB = new clsDB (configuration, "CineStar");
        }

        //obtener las peliculas segun el estado
        public List<Pelicula> GetPeliculasByEstado(int idEstado)
        {
            _clsDB.Sentencia($"EXEC sp_getPeliculas {idEstado}");

            string[][]? rd = _clsDB.getRegistros();
            List<Pelicula> lista = new List<Pelicula>();
            if (rd == null) return new List<Pelicula>();
            foreach (string[] r in rd)
            {
                lista.Add(new Pelicula
                {
                    id = int.Parse(r[0]),
                    Titulo = r[1],
                    Link = r[2],
                    Sinopsis = r[3]
                });
            }
            return lista;
        }
        //obtener datos de una pelicula 
        public Pelicula GetPeliculaById(int idPeli)
        {
            _clsDB.Sentencia($"EXEC sp_getPelicula {idPeli}");
            string[]? rd = _clsDB.getRegistro();
            if (rd == null) return null;
            return new Pelicula
            {
                id = int.Parse(rd[0]),
                Titulo = rd[1],
                FechaEstreno = rd[2],
                Director = rd[3],
                Generos = rd[4],
                idClasificacion = int.Parse(rd[5]),
                idEstado = int.Parse(rd[6]),
                Duracion = rd[7],
                Link = rd[8],
                Reparto = rd[9],
                Sinopsis = rd[10],
                GenerosDetalle = rd[11],
            };
            
        }
    }
}
