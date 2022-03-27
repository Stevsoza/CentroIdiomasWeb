using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVC.Models
{
    public class Feriado
    {
        [Key]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage ="Se requiere la descripcion de este feriado")]       
        [StringLength(100, ErrorMessage ="Se permite un máximo de 100 caracteres")]
        public string Descripcion { get; set; }
    }
}
