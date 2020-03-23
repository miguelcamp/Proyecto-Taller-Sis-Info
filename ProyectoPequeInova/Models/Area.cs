using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPequeInova.Models
{
    public class Area
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public IEnumerable<Curso> cursos { get; set; }
    }
}
