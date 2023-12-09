using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class EventosController : Controller
    {
        private readonly IAPIServices _APIServices;

        public EventosController(IAPIServices servicios)
        {
            _APIServices = servicios;
        }

        public async Task<IActionResult> Index(User user)
        {
            ViewBag.User = user;
            var eventos = await _APIServices.GetEventos();

            return View(eventos);
        }

        public async Task<IActionResult> Details(int IdEvento)
        {
            var evento = await _APIServices.GetEvento(IdEvento);
            if (evento != null) return View(evento);
            return RedirectToAction("Index");
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Eventos evento)
        {
            await _APIServices.POSTEventos(evento);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdEvento)
        {
            var evento = await _APIServices.GetEvento(IdEvento);
            if (evento != null) return View(evento);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Eventos evento)
        {
            await _APIServices.PUTEventos(evento.idEvento, evento);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int IdEvento)
        {
            Console.WriteLine($"El Id enviado fue: {IdEvento}");
            await _APIServices.DeleteEventos(IdEvento);

            return RedirectToAction("Index");
        }

    }
}
