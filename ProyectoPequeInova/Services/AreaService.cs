using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProyectoPequeInova.Data.Entity;
using ProyectoPequeInova.Data.Repository;
using ProyectoPequeInova.Exceptions;
using ProyectoPequeInova.Models;

namespace ProyectoPequeInova.Services
{
    public class AreaService : IAreaService
    {
        private IPequeInovaRepository areaRapository;
        private readonly IMapper mapper;
        public AreaService(IPequeInovaRepository pequeInovaRepository, IMapper mapper)
        {
            this.areaRapository = pequeInovaRepository;
            this.mapper = mapper;
        }
        public async Task<Area> ActualizarAreaAsync(int id, Area nuevaArea)
        {
            if (id != nuevaArea.Id)
            {
                throw new InvalidOperationException("URL id needs to be the same as Author id");
            }
            await ValidateArea(id);

            nuevaArea.Id = id;
            var areaEntity = mapper.Map<AreaEntity>(nuevaArea);
            areaRapository.ActualizarAreaAsync(areaEntity);
            if (await areaRapository.SaveChangesAsync())
            {
                return mapper.Map<Area>(areaEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public async Task<bool> BorrarAreaAsync(int id)
        {
            await ValidateArea(id);
            await areaRapository.EliminarAreaAsync(id);
            if (await areaRapository.SaveChangesAsync())
            {
                return true;
            }
            return false;
        }

        public async Task<Area> CrearAreaAsync(Area nuevaArea)
        {
            var areaEntity = mapper.Map<AreaEntity>(nuevaArea);

            areaRapository.AñadirAreaAsync(areaEntity);
            if (await areaRapository.SaveChangesAsync())
            {
                return mapper.Map<Area>(areaEntity);
            }

            throw new Exception("There were an error with the DB");
        }

        public async Task<Area> ObtenerAreaAsync(int id, bool mostrarCursos)
        {
            var areaEntity = await areaRapository.ObtenerAreaAsync(id, mostrarCursos);

            if (areaEntity == null)
            {
                throw new NotFoundException("area not found");
            }

            return mapper.Map<Area>(areaEntity);
        }

        public async Task<IEnumerable<Area>> ObtenerAreasAsync(string orderBy, bool mostrarCursos)
        {
            orderBy = orderBy.ToLower();
            //if (!allowedOrderByQueries.Contains(orderBy))
            //{
            //    throw new InvalidOperationException($"Invalid \" {orderBy} \" orderBy query param. The allowed values are {string.Join(",", allowedOrderByQueries)}");
            //}

            var areaEntities = await areaRapository.ObtenerAreas(orderBy, mostrarCursos);
            return mapper.Map<IEnumerable<Area>>(areaEntities);
        }
        private async Task ValidateArea(int id)
        {
            var author = await areaRapository.ObtenerAreaAsync(id);
            if (author == null)
            {
                throw new NotFoundException("invalid author to delete");
            }
            areaRapository.DetachEntity(author);
        }
    }
}
