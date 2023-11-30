using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Vendedor
    {
        [Key]
        public int Cedula { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public int CantidadVentas
        {
            get;
            set;
        }
        [Required]
        public string EsActivo { get; set; }
    }
}
