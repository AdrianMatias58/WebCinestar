using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebCinestar.Repositories;

namespace WebCinestar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCinestarController : ControllerBase
    {
        private readonly CineRepo _cRepo;
        private readonly PeliculaRepo _pRepo;
        public ApiCinestarController(IConfiguration configuration)
        {
            _cRepo = new CineRepo(configuration);
            _pRepo = new PeliculaRepo(configuration);
        }
        // GET: api/ApiCinestar/cines
        [HttpGet("cines")]
        public IActionResult GetCines()
        {
            var cines = _cRepo.GetCines();
            return Ok(cines);
        }

        // GET: api/ApiCinestar/cine/3
        [HttpGet("cine/{id}")]
        public IActionResult GetCine(int id)
        {
            var cine = _cRepo.GetCine(id);
            if (cine == null) return NotFound();
            return Ok(cine);
        }

        // GET: api/ApiCinestar/cine/3/tarifas
        [HttpGet("cine/{id}/tarifas")]
        public IActionResult GetTarifas(int id)
        {
            var tarifas = _cRepo.GetTarifas(id);
            return Ok(tarifas);
        }

        // GET: api/ApiCinestar/cine/3/peliculas
        [HttpGet("cine/{id}/peliculas")]
        public IActionResult GetCinePeliculas(int id)
        {
            var peliculas = _cRepo.GetPeliculas(id);
            return Ok(peliculas);
        }

        // GET: api/ApiCinestar/peliculas?idEstado=
        [HttpGet("peliculas")]
        public IActionResult GetPeliculas(int idEstado )
        {
            var peliculas = _pRepo.GetPeliculasByEstado(idEstado);
            return Ok(peliculas);
        }

        // GET: api/ApiCinestar/pelicula/idPelicula
        [HttpGet("pelicula/{id}")]
        public IActionResult GetPelicula(int id)
        {
            var pelicula = _pRepo.GetPeliculaById(id);
            if (pelicula == null) return NotFound();
            return Ok(pelicula);
        }

    }
}
