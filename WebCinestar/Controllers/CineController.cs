using Microsoft.AspNetCore.Mvc;
namespace WebCinestar.Controllers
{
    public class CineController : Controller
    {
        public IActionResult Inicio()
        {
            return View();
        }
        public IActionResult verCines()
        {
            return View();
        }
        public IActionResult verCine(int idCine )
        {
            return View();
        }
    }
}
