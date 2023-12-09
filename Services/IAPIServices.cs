using CRUD_MVC.Models;

namespace CRUD_MVC.Services
{
    public interface IAPIServices
    {
        public Task<List<Producto>> GetProducts();
        public Task<Producto> GetProduct(int id);
        public Task<Producto> PUTProducto(int IdProducto, Producto producto);
        public Task<Producto> POSTProducto(Producto producto);
        public Task DeleteProducto(int id);
        public Task<User> GetUser(string Cedula, string Clave);
        public Task<User> GetUser(int idUsuario);
        public Task<User> PutUser(int idUsuario, User user);
        public Task<User> POSTUser(User user);
        public Task<List<User>> GetUsers();
        public Task<List<Eventos>> GetEventos();
        public Task<Eventos> GetEvento(int idEvento);
        public Task<Eventos> PUTEventos(int idEvento, Eventos evento);
        public Task<Eventos> POSTEventos(Eventos evento);
        public Task DeleteEventos(int idEvento);
    }
}
