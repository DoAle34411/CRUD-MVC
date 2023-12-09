using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

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
            ViewBag.User = usuario_encontrado;
            return View(usuario_encontrado);
        }

        [HttpPost]
        public IActionResult Index()
        {
            if (HttpContext.Request.Method == "POST")
            {
                var userJson = HttpContext.Request.Form["user"];
                var user = JsonSerializer.Deserialize<User>(userJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                ViewBag.User = user;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Privacy()
        {
            if (HttpContext.Request.Method == "POST")
            {
                var userJson = HttpContext.Request.Form["user"];
                var user = JsonSerializer.Deserialize<User>(userJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                ViewBag.User = user;
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