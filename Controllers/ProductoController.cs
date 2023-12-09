using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.ConstrainedExecution;
using System.Text.Json;

namespace CRUD_MVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IAPIServices _APIServices;

        public ProductoController(IAPIServices servicios)
        {
            _APIServices = servicios;
        }


        // GET: ProductoController
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
            var productos = await _APIServices.GetProducts();
            return View(productos);
        }

        public async Task<IActionResult> Index(int IdUsuario)
        {
            Console.WriteLine(IdUsuario);
            var user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;

            // Rest of your code
            var productos = await _APIServices.GetProducts();
            return View(productos);
        }


        public async Task<IActionResult> Details(int IdProducto, int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            var producto = await _APIServices.GetProduct(IdProducto);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        public IActionResult Create(int IdUsuario)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            await _APIServices.POSTProducto(producto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int IdProducto, int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            var producto = await _APIServices.GetProduct(IdProducto);
            if (producto != null) return View(producto);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int IdProducto, string Nombre, string Descripcion, int Cantidad, string Autor, string Genero, int IdUsuario)
        {
            Producto producto = new Producto();
            Console.WriteLine(IdProducto+Nombre);
            producto.IdProducto = IdProducto;
            producto.Nombre = Nombre;
            producto.Descripcion = Descripcion;
            producto.Cantidad=Cantidad;
            producto.Autor = Autor;
            producto.Genero = Genero;
            Console.WriteLine(IdUsuario);
            await _APIServices.PUTProducto(producto.IdProducto, producto);
            Console.WriteLine(1122);
            return RedirectToAction("Index", IdUsuario);
        }

        public async Task<IActionResult> Delete(int IdProducto, int IdUsuario)
        {
            User user = await _APIServices.GetUser(IdUsuario);
            ViewBag.User = user;
            Console.WriteLine($"El Id enviado fue: {IdProducto}");
            await _APIServices.DeleteProducto(IdProducto);

            return RedirectToAction("Index");
        }


    }
}
