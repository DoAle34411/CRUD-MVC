using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class VendedorController : Controller
    {
        private readonly IAPIServices _APIServices;

        public VendedorController(IAPIServices servicios)
        {
            _APIServices = servicios;
        }


        // GET: ProductoController
        public async Task<IActionResult> Indice()
        {
            var sellers = await _APIServices.GetSellers();

            return View(sellers);
        }

        // GET: ProductoController/Details/5
        /*public IActionResult Details(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        } */

        public async Task<IActionResult> Details(int Cedula)
        {
            var vendedor = await _APIServices.GetSeller(Cedula);
            if (vendedor != null) return View(vendedor);
            return RedirectToAction("Indice");
        }

        // GET: ProductoController/Create
        public IActionResult CrearV()
        {
            return View();
        }

        [HttpPost]
        /*public IActionResult Create(Producto producto)
        {
            int id = Utils.ListaProducto.Count() + 1;
            producto.IdProducto = id;
            Utils.ListaProducto.Add(producto);
            return RedirectToAction("Index");
        }*/

        public async Task<IActionResult> CrearV(Vendedor vendedor)
        {
            await _APIServices.POSTSeller(vendedor);
            return RedirectToAction("Indice");
        }

        // GET: ProductoController/Edit/5
        /*public IActionResult Edit(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(Producto nuevo)
        {
            Producto antiguo = Utils.ListaProducto.Find(x => x.IdProducto == nuevo.IdProducto);
            if (antiguo != null)
            {
                antiguo.Nombre = nuevo.Nombre;
                antiguo.Descripcion = nuevo.Descripcion;
                antiguo.Cantidad = nuevo.Cantidad;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        } */

        public async Task<IActionResult> Edit(int Cedula)
        {
            var vendedor = await _APIServices.GetSeller(Cedula);
            if (vendedor != null) return View(vendedor);
            return RedirectToAction("Indice");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Vendedor vendedor)
        {
            await _APIServices.PUTSeller(vendedor.Cedula, vendedor);
            return RedirectToAction("Indice");
        }

        // GET: ProductoController/Delete/5
        /*public IActionResult Delete(int IdProducto)
        {
            Producto producto = Utils.ListaProducto.Find(x => x.IdProducto == IdProducto);
            if (producto != null)
            {
                Utils.ListaProducto.Remove(producto);
            }
            return RedirectToAction("Index");
        } */

        public async Task<IActionResult> Delete(int Cedula)
        {
            Console.WriteLine($"El Id enviado fue: {Cedula}");
            await _APIServices.DeleteSeller(Cedula);

            return RedirectToAction("Indice");
        }


    }
}