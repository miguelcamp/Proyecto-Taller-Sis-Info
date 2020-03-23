using ProyectoPequeInova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPequeInova.Services
{
    public interface IAreaService
    {
        Task<Area> CrearAreaAsync(Area nuevaArea);
        Task<IEnumerable<Area>> ObtenerAreasAsync(string orderBy, bool mpstrarCursos);
        Task<Area> ObtenerAreaAsync(int id, bool mostrarCursos);
        Task<Area> ActualizarAreaAsync(int id, Area nuevaArea);
        Task<bool> BorrarAreaAsync(int id);
    }
}
