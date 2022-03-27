using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Profesor: Usuario
    {
        [Key]
        public int Id_Profesor { get; set; }

        [Required(ErrorMessage ="Se requiere el idioma del profesor")]
        [Display(Name ="Idioma")]
        public string Idioma { get; set;  }

        [Required(ErrorMessage ="Se requiere Hora de Entrada")]
        [Display(Name ="Hora de entrada")]
        [DataType(DataType.Time)]
        public DateTime Hora_Entrada { get; set; }
        
        
        [Required(ErrorMessage ="Se requiere Hora de Entrada")]
        [Display(Name ="Hora de Salida")]
        [DataType(DataType.Time)]
        public DateTime Hora_Salida{ get; set; }

        /*public virtual ICollection<Clase> clases { get; set; }*/
    }
}
