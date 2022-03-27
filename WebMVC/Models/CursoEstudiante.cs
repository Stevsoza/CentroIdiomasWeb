using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class CursoEstudiante
    {
        [Required(ErrorMessage ="Se necesita una fecha de inicio")]
        [DataType(DataType.DateTime)]
        [Display(Name ="Fecha Inicio")]
        public DateTime Fecha_inicio { get; set; }

        [Required(ErrorMessage = "Se necesita una fecha de final")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha Final")]
        public DateTime Fecha_final { get; set; }

        [Required(ErrorMessage ="Se requiere el estado del curso")]
        [StringLength(3)]
        [Display(Name ="Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage ="Se requieren las horas restantes sincronicas")]
        [Display(Name ="Horas Sincronicas Restantes")]
        public int Horas_sinc_res { get; set; }

        [ForeignKey("Fk_Estudiante")]
        public int Id_estudiante { get; set; }

        /*[Display(Name = "Datos del estudiante")]
        public Estudiante estudiante { get; set; }*/

        [ForeignKey("FK_Curso")]
        public int Id_curso { get; set; }

        /*[Display(Name = "Datos del curso")]

        public Curso curso { get; set; }*/
    }
}
