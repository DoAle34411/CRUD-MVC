using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Eventos
    {
        [Required]
        public int idEvento { get; set; }
        [Required]
        public string NombreEvento { get; set; }
        [Required]
        public string DescripcionEvento { get; set; }
        [Required]
        public DateTime diaEvento { get; set; }
        public TimeSpan horaEvento { get; set; }
        public string Expositores { get; set; }
    }
}
