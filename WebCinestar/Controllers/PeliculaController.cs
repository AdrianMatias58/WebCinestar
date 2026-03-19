using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;
using WebCinestar.Repositories;

namespace WebCinestar.Controllers
{
    public class PeliculaController : Controller
    {
        private readonly PeliculaRepo _Pr;
        public PeliculaController(IConfiguration conf)
        {
            _Pr = new PeliculaRepo(conf);
        }
        public IActionResult verPeliculas(int id)
        {
            var peliculas = _Pr.GetPeliculasByEstado(id);
            ViewBag.idEstado = id;  
            return View(peliculas);
        }
        public IActionResult verPelicula(int idPelicula)
        {
            var pelicula = _Pr.GetPeliculaById(idPelicula);
            return View(pelicula);
        }
    }
}
