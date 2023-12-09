using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;

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
            var productos = await _APIServices.GetUsers();

            return View(productos);
        }

        public async Task<IActionResult> Details(int IdProducto)
        {
            var producto = await _APIServices.GetProduct(IdProducto);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            await _APIServices.POSTProducto(producto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdProducto)
        {
            var producto = await _APIServices.GetProduct(IdProducto);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            await _APIServices.PUTProducto(producto.IdProducto, producto);
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
