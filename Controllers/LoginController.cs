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
            _apiService = apiServiceUsuario;
        }
        public IActionResult Index()
        {
            Console.WriteLine("Nada");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string Cedula, string Clave)
        {
            Console.WriteLine("EnvioDatos");
            User usuario_encontrado = await _apiService.GetUser(Cedula, Clave);
            Console.WriteLine(usuario_encontrado.Nombres);
            if (usuario_encontrado == null || usuario_encontrado.Nombres == null)
            {
                Console.WriteLine("UsuarioNoEncontrado1");
                return View();
            }
            Console.WriteLine("UsuarioEncontradoMVC1");
            return RedirectToAction("Index", "Home", usuario_encontrado);
        }
        public IActionResult SignUp()
        {
            Console.WriteLine("Nada");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(User user)
        {
            Console.WriteLine("EnvioDatos");
            User usuario_encontrado = await _apiService.GetUser(user.Cedula, user.Clave);
            if (usuario_encontrado != null || usuario_encontrado.Nombres != null)
            {
                Console.WriteLine("UsuarioNoEncontradoMVC");
                await _apiService.POSTUser(user);
                return RedirectToAction("Index", "Home", usuario_encontrado);
            }
            else
            {
                Console.WriteLine("UsuarioEncontradoMVC");
                return View();
            }

        }
    }
}
