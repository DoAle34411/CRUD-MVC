using CRUD_MVC.Models;
using CRUD_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_MVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAPIServices _apiService;
        public LoginController(IAPIServices apiServiceUsuario)
        {
            _apiService= apiServiceUsuario;
        }
        public IActionResult Index()
        {
            Console.WriteLine("Nada");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(User usuarioP)
        {
            Console.WriteLine("EnvioDatos");
            User usuario_encontrado = await _apiService.GetUser(usuarioP.IdUsuario, usuarioP.Clave);
            if (usuario_encontrado == null)
            {
                Console.WriteLine("UsuarioNoEncontradoMVC");
                return View();
            }
            Console.WriteLine("UsuarioEncontradoMVC");
            return RedirectToAction("Index", "Home");
            

        }
    }
}
