using CRUD_MVC.Models;
using Newtonsoft.Json;

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

        public async Task<Vendedor> GetSeller(int Cedula)
        {
             try
             {
                 var vendedor = await _httpClient.GetFromJsonAsync<Vendedor>("api/Vendedor/" + Cedula);
                 return vendedor;
             }
             catch (Exception ex)
             {
                 return new Vendedor();
             }
            
        }

        public async Task<List<Vendedor>> GetSellers()
        {

            var response = await _httpClient.GetAsync("api/Vendedor/");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Vendedor> vendedor = JsonConvert.DeserializeObject<List<Vendedor>>(json_response);
                return vendedor;
            }
            return new List<Vendedor>();
            //var vendedores = await _httpClient.GetFromJsonAsync<List<Vendedor>>("api/Vendedor");
           
            //return vendedores;
        }

        public async Task<User> GetUser(int IdUsuario, string Clave)
        {
            try
            {
                var usuario = await _httpClient.GetFromJsonAsync<User>($"/api/User/{IdUsuario}/{Clave}");
                return usuario;
            }
            catch (Exception ex)
            {
                return new User();
            }
        }

        public async Task<Producto> POSTProducto(Producto producto)
        {
            await _httpClient.PostAsJsonAsync("api/Producto", producto);
            return producto;
        }

        public async Task<Vendedor> POSTSeller(Vendedor vendedor)
        {
            await _httpClient.PostAsJsonAsync("api/Vendedor", vendedor);
            return vendedor;
        }

        public async Task<Producto> PUTProducto(int IdProducto, Producto producto)
        {
            await _httpClient.PutAsJsonAsync("api/Producto/" + IdProducto, producto);
            return producto;
        }

        public async Task<Vendedor> PUTSeller(int Cedula, Vendedor vendedor)
        {
            await _httpClient.PutAsJsonAsync("api/Vendedor/" + Cedula, vendedor);
            return vendedor;
        }
    }
}
