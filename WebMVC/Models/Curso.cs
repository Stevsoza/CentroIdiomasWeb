using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Curso
    {
        [Key]
        public int Id_curso { get; set; }

        [Display(Name = "Nombre Curso")]
        [StringLength(20, ErrorMessage = "se permite 20 caracteres como máximo")]
        public string Nombre_Curso { get; set; }

        [Display(Name = "Requisito")]
        public string Requisito { get; set; }

        [Required(ErrorMessage = "Se requiere las horas del curso")]
        [Column(TypeName = "int")]
        [Display(Name = "Horas")]
        public int Horas { get; set; }

        [Required(ErrorMessage = "Se requiere el costo del curso")]
        [Column(TypeName = "Decimal(10,2)")]
        [Display(Name = "Costo")]
        public decimal Costo { get; set; }

        [ForeignKey("Fk_Programa")]
        public int Id_programa { get; set; }

        /*[Display(Name = "Datos del Programa")]
        public Programa programa { get; set; }*/

        /*[Display(Name = "Lista de cursos")]
        public virtual ICollection<CursoEstudiante> cursoEstudiantes { get; set; }*/
    }
}
