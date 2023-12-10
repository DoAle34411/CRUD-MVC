using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CRUD_MVC.Controllers
{
    public class EventosController : Controller
    {
        private readonly IAPIServices _APIServices;

        public EventosController(IAPIServices servicios)
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
            }
            var eventos = await _APIServices.GetEventos();

            return View(eventos);
        }

        public async Task<IActionResult> Index(int IdUsuario)
        {
            var user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            var eventos = await _APIServices.GetEventos();
            return View(eventos);
        }

        public async Task<IActionResult> Details(int IdEvento, int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            var evento = await _APIServices.GetEvento(IdEvento);
            if (evento != null) return View(evento);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public async Task<IActionResult> Create(int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Eventos evento)
        {
            int IdUsuario = evento.IdUsuario;
            Console.WriteLine(IdUsuario);
            await _APIServices.POSTEventos(evento);
            return RedirectToAction("Index", new { IdUsuario = IdUsuario });
        }

        public async Task<IActionResult> Edit(int IdEvento, int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            var evento = await _APIServices.GetEvento(IdEvento);
            if (evento != null) return View(evento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Eventos evento)
        {
            int IdUsuario = evento.IdUsuario;
            Console.WriteLine(IdUsuario);
            await _APIServices.PUTEventos(evento.idEvento, evento);
            Console.WriteLine(1122);
            return RedirectToAction("Index", new { IdUsuario = IdUsuario });
        }

        public async Task<IActionResult> Delete(int IdEvento, int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            Console.WriteLine($"El Id enviado fue: {IdEvento}");
            await _APIServices.DeleteEventos(IdEvento);
            return RedirectToAction("Index", new { IdUsuario = IdUsuario });
        }

    }
}
