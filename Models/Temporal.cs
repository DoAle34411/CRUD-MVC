using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class Temporal
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public int IdLibro { get; set; }
        [Required]
        public int IdUsuarioActivo { get; set; }

    }
}
