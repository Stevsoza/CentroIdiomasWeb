using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Programa
    {
        [Key]
        [Display(Name ="Id Programa")]
        public int Id_programa { get; set; }

        [Required(ErrorMessage ="Se necesita el Idioma del programa")]
        [StringLength(20, ErrorMessage ="Debe ser de máximo 20 caracteres")]
        [Display(Name ="Idioma")]
        public string Idioma { get; set; }

        [Display(Name ="Cursos")]
        public int? cursos { get; set; }

        /*public virtual ICollection<Curso> Cursos { get; set; }*/
    }
}
