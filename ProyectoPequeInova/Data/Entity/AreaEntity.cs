using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPequeInova.Data.Entity
{
    public class AreaEntity
    {

        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual ICollection<CursoEntity> Cursos { get; set; }

    }
}
