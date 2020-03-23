using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPequeInova.Data.Entity
{
    public class CursoEntity
    {
        [Key]
        [Required]
        public int? Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [ForeignKey("AreaId")]
        public virtual AreaEntity Area { get; set; }
    }
}
