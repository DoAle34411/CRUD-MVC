using CRUD_MVC.Models;

namespace CRUD_MVC.Services
{
    public class APIServices : IAPIServices
    {
        public static string _baseUrl;
        public HttpClient _httpClient;

        public APIServices(IConfiguration configuration)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = new Uri(configuration["API:Url"])
            };
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("API:Url").Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);

        }

        public async Task DeleteEventos(int idEvento)
        {
            await _httpClient.DeleteAsync("api/Eventos/" + idEvento);
        }

        public async Task DeleteProducto(int id)
        {
            await _httpClient.DeleteAsync("api/Producto/" + id);
        }
        public async Task<Eventos> GetEvento(int idEvento)
        {
            try
            {
                var eventos = await _httpClient.GetFromJsonAsync<Eventos>("api/Eventos/" + idEvento);
                return eventos;
            }
            catch (Exception ex)
            {
                return new Eventos();
            }
        }

        public async Task<List<Eventos>> GetEventos()
        {
            var eventos = await _httpClient.GetFromJsonAsync<List<Eventos>>("api/Eventos");
            return eventos;
        }

        public async Task<Producto> GetProduct(int id)
        {
            try
            {
                var producto = await _httpClient.GetFromJsonAsync<Producto>("api/Producto/" + id);
                return producto;
            }
            catch (Exception ex)
            {
                return new Producto();
            }
        }

        public async Task<List<Producto>> GetProducts()
        {
            var productos = await _httpClient.GetFromJsonAsync<List<Producto>>("api/Producto");
            return productos;
        }

        public async Task<User> GetUser(string Cedula, string Clave)
        {
            try
            {
                var usuario = await _httpClient.GetFromJsonAsync<User>($"api/User/{Cedula}/{Clave}");
                return usuario;
            }
            catch (Exception ex)
            {
                return new User();
            }
        }

        public async Task<User> GetUser(int IdUsuario)
        {
            try
            {
                var usuario = await _httpClient.GetFromJsonAsync<User>($"api/User/{IdUsuario}");
                return usuario;
            }
            catch (Exception ex)
            {
                return new User();
            }
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>("api/User");
            return users;
        }

        public async Task<Eventos> POSTEventos(Eventos evento)
        {
            await _httpClient.PostAsJsonAsync("api/Eventos", evento);
            return evento;
        }

        public async Task<Producto> POSTProducto(Producto producto)
        {
            await _httpClient.PostAsJsonAsync("api/Producto", producto);
            return producto;
        }

        public async Task<User> POSTUser(User user)
        {
            await _httpClient.PostAsJsonAsync("api/User", user);
            return user;
        }

        public async Task<Eventos> PUTEventos(int idEvento, Eventos evento)
        {
            await _httpClient.PutAsJsonAsync("api/Eventos/" + idEvento, evento);
            return evento;
        }

        public async Task<Producto> PUTProducto(int IdProducto, Producto producto)
        {
            await _httpClient.PutAsJsonAsync("api/Producto/" + IdProducto, producto);
            return producto;
        }

        public async Task<User> PutUser(int idUsuario, User user)
        {
            await _httpClient.PutAsJsonAsync("api/User/" + idUsuario, user);
            return user;
        }
    }
}
