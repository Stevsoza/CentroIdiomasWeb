using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Estudiante : Usuario
    {
        [Key]
        [Display(Name ="ID")]
        public int Id_estudiante { get; set; }

        [Display(Name ="Cursos Matriculados")]
        public int Cursos_matriculados { get; set; }

        [Display(Name ="Deuda")]
        public bool Deuda { get; set; }

        /*[Display(Name = "Lista de Cursos")]
        public virtual ICollection<CursoEstudiante> cursosEstudiante { get; set; }

        [Display(Name = "Lista de Clases")]
        public virtual ICollection<Clase> clases { get; set; }

        [Display(Name = "Lista de Matriculas")]
        public virtual ICollection<Matricula> matriculas { get; set; }*/

    }
}
