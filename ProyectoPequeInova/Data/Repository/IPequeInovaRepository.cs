using ProyectoPequeInova.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoPequeInova.Data.Repository
{
    public interface IPequeInovaRepository
    {
        //areas
        Task<AreaEntity> ObtenerAreaAsync(int id, bool mostrarCursos = true);
        Task<IEnumerable<AreaEntity>> ObtenerAreas(string orderBy = "id", bool mostrarCursos = true);
        Task EliminarAreaAsync(int id);
        void ActualizarAreaAsync(AreaEntity area);
        void AñadirAreaAsync(AreaEntity area);

        //cursos
        Task<IEnumerable<CursoEntity>> ObtenerCursos(int areaId);
        Task<IEnumerable<CursoEntity>> ObtenerTodosCursos();
        Task<CursoEntity> ObtenerCusrosAsync(int id, bool mostrarArea = false);
        void AñadirCurso(CursoEntity curso);
        void ActualizarCurso(CursoEntity curso);
        Task EliminarCurso(int id);


        //esto que no recuerdo
        void DetachEntity<t>(t entity) where t : class;
        Task<bool> SaveChangesAsync();
    }
}
