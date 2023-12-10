using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRUD_MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IAPIServices _APIServices;

        public UserController(IAPIServices servicios)
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
            var users = await _APIServices.GetUsers();
            return View(users);
        }

        public async Task<IActionResult> Index(int IdUsuario)
        {
            var user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            var users = await _APIServices.GetUsers();
            return View(users);
        }

        public async Task<IActionResult> Details(int IdUsuario, int IdUsuario2)
        {
            User user = await _APIServices.GetUser(IdUsuario2);
            ViewBag.User = user;
            var user2 = await _APIServices.GetUser(IdUsuario);
            if (user2 != null) return View(user2);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Create(int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            int IdUsuario2 = user.IdUsuarioActivo;
            Console.WriteLine(IdUsuario2);
            await _APIServices.POSTUser(user);
            return RedirectToAction("Index", new { IdUsuario = IdUsuario2 });
        }

        public async Task<IActionResult> Edit(int IdUsuario, int IdUsuario2)
        {
            User user = await _APIServices.GetUser(IdUsuario2);
            ViewBag.User = user;
            var user2 = await _APIServices.GetUser(IdUsuario);
            if (user2 != null) return View(user2);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            int IdUsuarioActivo = user.IdUsuarioActivo;
            Console.WriteLine(IdUsuarioActivo);
            await _APIServices.PutUser(user.IdUsuario, user);
            Console.WriteLine(1122);
            return RedirectToAction("Index", new { IdUsuario = IdUsuarioActivo });
        }

        public async Task<IActionResult> Delete(int IdProducto)
        {
            Console.WriteLine($"El Id enviado fue: {IdProducto}");
            await _APIServices.DeleteProducto(IdProducto);

            return RedirectToAction("Index");
        }
    }
}
