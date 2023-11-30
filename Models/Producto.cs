using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public int Cantidad { get; set; }
        [Required]
        public string Autor { get; set; }
        [Required]
        public double Costo
        {
            get;
            set;
        }
        [Required]
        public string Genero { get; set; }
    }
}
