using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Clase
    {
        [Key]
        public int Id_clase { get; set; }        

        [DataType(DataType.DateTime)]
        [Display(Name ="Inicio clase")]
        public DateTime Inicio { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name ="Fin clase")]
        public DateTime Final { get; set; }

        [ForeignKey("Fk_estudiante")]
        public int Id_estudiante { get; set; }

        /*[Display(Name = "Datos del estudiante")]
        public Estudiante estudiante { get; set; }*/

        [ForeignKey("Fk_curso")]
        public int Id_curso { get; set; }

        /*[Display(Name = "Datos del Curso")]
        public Curso curso { get; set; }*/

        [ForeignKey("Fk_profesor")]
        public int Id_profesor { get; set; }

        /*[Display(Name = "Datos del Profesor")]
        public Profesor profesor { get; set; }*/
    }
}
