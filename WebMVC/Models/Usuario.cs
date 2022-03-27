using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    abstract public class Usuario
    {
        [Required(ErrorMessage = "Se requiere un nombre")]
        [StringLength(20, ErrorMessage = "El nombre debe ser de máximo 20 caracteres")]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El primer apellido es requerido")]
        [StringLength(15, ErrorMessage = "Para el apellido se permite un máximo de 15 caracteres")]
        [Display(Name ="Primer Apellido")]
        public string P_apellido { get; set; }

        [Required(ErrorMessage = "El segundo apellido es requerido")]
        [StringLength(15, ErrorMessage = "Para el segundo apellido se permite un máximo de 15 caracteres")]
        [Display(Name ="Segundo Apellido")]
        public string S_Apellido { get; set; }

        [Required(ErrorMessage ="Se requiere la Edad")]
        [Range(1, 150, ErrorMessage = "Como máxima edad se permite 150")]
        [Display(Name ="Edad")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El número telefónico es requerido")]
        [StringLength(15, ErrorMessage = "El número telefonico debe tener 15 caracteres como máximo")]
        [Display(Name ="Telefóno")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [StringLength(50, ErrorMessage = "Para el email se permite un máximo de 50 caracteres")]
        [Display(Name ="Email")]

        public string Email { get; set; }
    }
}
