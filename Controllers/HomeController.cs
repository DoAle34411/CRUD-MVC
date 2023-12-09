using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAPIServices _APIServices;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(User usuario_encontrado)
        {
            return View(usuario_encontrado);
        }

        [HttpPost]
        public IActionResult Privacy(int IdUsuario, string Cedula, string Nombres, string Apellidos, string Clave, int CodigoAcceso, bool HaRetirado, int IdLibroRetirado, int Destino)
        {
            // Create the Product object using the received parameters
            var user = new User
            {
                IdUsuario = IdUsuario,
                Cedula = Cedula,
                Nombres = Nombres,
                Apellidos = Apellidos,
                Clave = Clave,
                CodigoAcceso = CodigoAcceso,
                HaRetirado = HaRetirado,
                IdLibroRetirado = IdLibroRetirado,
            };
            if (user.CodigoAcceso == 1)
            {
                switch (Destino)
                {
                    case 1: return View("Index", user);
                    case 2: return View(user);
                    case 3: return RedirectToAction("Index", "Producto", user);
                    case 4: return RedirectToAction("Index", "Eventos", user);
                    case 5: return RedirectToAction("Index", "User", user);
                }
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}