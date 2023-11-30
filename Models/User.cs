using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CRUD_MVC.Models
{
    public class User
    {
        [Required]
        public int IdUsuario { get; set; }
        [Required]
        public string Clave { get; set; }
        [Required]
        public int codigoAcceso { get; set }
        
    }
}
