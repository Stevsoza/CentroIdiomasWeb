using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Login
    {
        [Key]
        [Required(ErrorMessage = "Se necesita el usuario")]
        [StringLength(20, ErrorMessage ="El nombre de usuario debe ser de máximo 20 caracteres")]
        public string Usuario { get; set; }

        
        [Required(ErrorMessage ="Se necesita la contraseña")]
        [StringLength(10, ErrorMessage ="La contraseña debe tener como máximo 10 caracteres")]
        [Display(Name ="Contraseña")]
        public string Contrasena { get; set; }

        [Display(Name ="Id estudiante")]
        public int? Id_estudiante { get; set; }

        /*[Display(Name = "Lista de estudiantes")]
        public ICollection<Estudiante> estudiante { get; set; }*/
    }
}
