using Microsoft.AspNetCore.Mvc;
using WebCinestar.Repositories;
namespace WebCinestar.Controllers
{
    public class CineController : Controller
    {
        private readonly CineRepo _repo;

        public CineController(IConfiguration configuration)
        {
            _repo = new CineRepo(configuration);
        }
        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult verCines()
        {
            var cines = _repo.GetCines();
            return View(cines);
        }
        public IActionResult verCine(int idCine )
        {
            var cine = _repo.GetCine(idCine);
            ViewBag.Tarifas = _repo.GetTarifas(idCine);   
            ViewBag.Peliculas = _repo.GetPeliculas(idCine);  
            return View(cine);
        }
    }
}
