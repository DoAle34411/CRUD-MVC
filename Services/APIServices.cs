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
        public async Task DeleteProducto(int id)
        {
            await _httpClient.DeleteAsync("api/Producto/" + id);
        }

        public async Task DeleteSeller(int Cedula)
        {
            await _httpClient.DeleteAsync("api/Vendedor/" + Cedula);
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

        public Task<User> GetUser(int idUsuario)
        {
            throw new NotImplementedException();
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

        public async Task<Producto> PUTProducto(int IdProducto, Producto producto)
        {
            await _httpClient.PutAsJsonAsync("api/Producto/" + IdProducto, producto);
            return producto;
        }

        public Task<User> PutUser(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
