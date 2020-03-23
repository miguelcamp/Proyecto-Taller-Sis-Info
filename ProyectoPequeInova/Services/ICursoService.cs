using ProyectoPequeInova.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPequeInova.Services
{
    public interface ICursoService
    {
        Task<IEnumerable<Curso>> ObtenerCurso(int areaId);
        Task<Curso> ObtenerCursoAsync(int areaId, int id);
        Task<IEnumerable<Curso>> ObtenerTodosCursos();
        Task<Curso> AñadirCursoAsync(int areaId, Curso curso);
        Task<Curso> ActualizarCursoAsync(int areaId, int id, Curso curso);
        Task<bool> EliminarCurso(int areaId, int id);
    }
}
