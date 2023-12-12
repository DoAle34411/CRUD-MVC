using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Producto
    {
        [Required]
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public string Genero { get; set; }
        public int IdUsuario { get; set; }
        public string urlImage { get; set; }
    }
}
