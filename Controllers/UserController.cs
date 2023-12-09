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
        public async Task<IActionResult> Index()
        {
            if (HttpContext.Request.Method == "POST")
            {
                var userJson = HttpContext.Request.Form["user"];
                var user = JsonSerializer.Deserialize<User>(userJson, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                ViewBag.User = user;
            }
            var users = await _APIServices.GetUsers();
            return View(users);
        }

        public async Task<IActionResult> Details(int IdUsuario)
        {
            var user = await _APIServices.GetUser(IdUsuario);
            if (user != null) return View(user);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await _APIServices.POSTUser(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdUsuario)
        {
            var user = await _APIServices.GetUser(IdUsuario);
            if (user != null) return View(user);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            await _APIServices.PutUser(user.IdUsuario, user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int IdProducto)
        {
            Console.WriteLine($"El Id enviado fue: {IdProducto}");
            await _APIServices.DeleteProducto(IdProducto);

            return RedirectToAction("Index");
        }
    }
}
