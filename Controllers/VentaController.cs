using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRUD_MVC.Controllers
{
    public class VentaController : Controller
    {
        private readonly IAPIServices _APIServices;

        public VentaController(IAPIServices servicios)
        {
            _APIServices = servicios;
        }
        [HttpPost]
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Request.Method == "POST")
            {
                var userJson = HttpContext.Request.Form["user"];
                var user = JsonSerializer.Deserialize<User>(userJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                ViewBag.User = user;
                Console.WriteLine(user.CodigoAcceso);
            }
            return View();
        }

        public async Task<IActionResult> Index(int IdUsuario)
        {
            var user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            return View();
        }
        public async Task<IActionResult> Devolver(int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Devolver(int IdUsuario, int IdLibro, int IdUsuarioActivo)
        {
            Console.WriteLine("hola2");
            Console.WriteLine(IdUsuario);
            Console.WriteLine(IdLibro);
            Console.WriteLine(IdUsuarioActivo);
            User user = await _APIServices.GetUser(IdUsuario);
            Producto producto = await _APIServices.GetProduct(IdLibro);
            if (user.HaRetirado) 
            {
                user.HaRetirado = false;
                user.IdLibroRetirado = 0;
                await _APIServices.PutUser(user.IdUsuario, user);
                producto.Cantidad++;
                await _APIServices.PUTProducto(producto.IdProducto, producto);
            }
            return RedirectToAction("Index", new { IdUsuario = IdUsuarioActivo });
        }
        public async Task<IActionResult> Retirar(int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Retirar(int IdUsuario, int IdLibro, int IdUsuarioActivo)
        {
            Console.WriteLine("hola");
            Console.WriteLine(IdUsuario);
            Console.WriteLine(IdLibro);
            Console.WriteLine(IdUsuarioActivo);
            User user = await _APIServices.GetUser(IdUsuario);
            Producto producto = await _APIServices.GetProduct(IdLibro);
            if (!user.HaRetirado)
            {
                user.HaRetirado = true;
                user.IdLibroRetirado = IdLibro;
                await _APIServices.PutUser(user.IdUsuario, user);
                producto.Cantidad--;
                await _APIServices.PUTProducto(producto.IdProducto, producto);
            }
            return RedirectToAction("Index", new { IdUsuario = IdUsuarioActivo });
        }
    }
}
