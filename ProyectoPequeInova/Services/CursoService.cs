using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoPequeInova.Models;

namespace ProyectoPequeInova.Services
{
    public class CursoService : ICursoService
    {
        public Task<Curso> ActualizarCursoAsync(int areaId, int id, Curso curso)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> AñadirCursoAsync(int areaId, Curso curso)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EliminarCurso(int areaId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Curso>> ObtenerCurso(int areaId)
        {
            throw new NotImplementedException();
        }

        public Task<Curso> ObtenerCursoAsync(int areaId, int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Curso>> ObtenerTodosCursos()
        {
            throw new NotImplementedException();
        }
    }
}
