using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoPequeInova.Data.Entity;

namespace ProyectoPequeInova.Data.Repository
{
    public class PequeInovaRepository : IPequeInovaRepository
    {
        private PequeInovaDBContext PIDBContext;

        public PequeInovaRepository(PequeInovaDBContext PIDBContext)
        {
            this.PIDBContext = PIDBContext;
        }
        public void ActualizarAreaAsync(AreaEntity area)
        {
            var areaPut = PIDBContext.Areas.Single(c => c.Id == area.Id);
            areaPut.nombre = area.nombre;
            areaPut.Descripcion = area.Descripcion;
        }

        public void ActualizarCurso(CursoEntity curso)
        {
            var cursoPut = PIDBContext.Cursos.Single(c => c.Id == curso.Id);
            cursoPut.Nombre = curso.Nombre;
            cursoPut.Descripcion = curso.Descripcion;
        }

        public void AñadirAreaAsync(AreaEntity area)
        {
            var saveArea= PIDBContext.Areas.Add(area);
        }

        public void AñadirCurso(CursoEntity curso)
        {
            PIDBContext.Entry(curso.Area).State = EntityState.Unchanged;
            PIDBContext.Cursos.Add(curso);
        }

        public void DetachEntity<t>(t entity) where t : class
        {
            PIDBContext.Entry(entity).State = EntityState.Detached;
        }

        public async Task EliminarAreaAsync(int id)
        {
            var area = await PIDBContext.Areas.SingleAsync(a => a.Id == id);
            PIDBContext.Areas.Remove(area);
        }

        public async Task EliminarCurso(int id)
        {
            var cursoEliminado = await PIDBContext.Cursos.SingleAsync(d => d.Id == id);
            PIDBContext.Cursos.Remove(cursoEliminado);
        }

        public async Task<AreaEntity> ObtenerAreaAsync(int id, bool mostrarCursos = true)
        {
            IQueryable<AreaEntity> query = PIDBContext.Areas;
            query = query.AsNoTracking();

            return await query.SingleOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<AreaEntity>> ObtenerAreas(string orderBy = "id", bool mostrarCursos = true)
        {
            IQueryable<AreaEntity> query = PIDBContext.Areas;
            if (mostrarCursos)
            {
                query = query.Include(a => a.Cursos);
            }
            switch (orderBy)
            {
                case "id":
                    query = query.OrderBy(a => a.Id);
                    break;
                case "nombre":
                    query = query.OrderBy(a => a.nombre);
                    break;
                default:
                    break;
            }

            return await query.ToArrayAsync();
        }

        public async Task<IEnumerable<CursoEntity>> ObtenerCursos(int areaId)
        {
            IQueryable<CursoEntity> query = PIDBContext.Cursos;
            query = query.AsNoTracking();
            return await query.Where(b => b.Area.Id == areaId).ToArrayAsync();
        }

        public Task<CursoEntity> ObtenerCusrosAsync(int id, bool mostrarArea = false)
        {
            IQueryable<CursoEntity> query = PIDBContext.Cursos;
            query = query.AsNoTracking();
            return query.SingleAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<CursoEntity>> ObtenerTodosCursos()
        {
            IQueryable<CursoEntity> query = PIDBContext.Cursos;
            query = query.AsNoTracking();
            return await query.ToArrayAsync();
        }

        public async Task<bool> SaveChangesAsync()
        {
            try
            {
                return (await PIDBContext.SaveChangesAsync()) > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
