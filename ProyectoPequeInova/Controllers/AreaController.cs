using Microsoft.AspNetCore.Mvc;
using ProyectoPequeInova.Exceptions;
using ProyectoPequeInova.Models;
using ProyectoPequeInova.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;


namespace ProyectoPequeInova.Controllers
{
    [Route("api/[controller]")]
    public class AreaController : ControllerBase
    {
        private IAreaService areaService;
        private ICursoService cursoService;

        public AreaController(IAreaService areaService, ICursoService cursoService)
        {
            this.areaService = areaService;
            this.cursoService = cursoService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> Get(string orderBy = "Id", bool showCanciones = false)
        {
            try
            {
                return Ok(await areaService.ObtenerAreasAsync(orderBy, showCanciones));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");

            }
        }
        [HttpGet("allcanciones")]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCacniones()
        {
            try
            {
                return Ok(await cursoService.ObtenerTodosCursos());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");

            }
        }
        [HttpGet("{areaId:int}")]
        public async Task<ActionResult<Area>> Get(int areaId, bool showCanciones = true)
        {
            try
            {
                var area = await this.areaService.ObtenerAreaAsync(areaId, showCanciones);
                return Ok(area);

            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<ActionResult<Area>> Post([FromBody] Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newarea = await this.areaService.CrearAreaAsync(area);
            return Created($"/api/areas/{newarea.Id}", newarea);
        }

        [HttpDelete("{areaId:int}")]
        public async Task<ActionResult<bool>> Delete(int areaId)
        {
            try
            {
                return Ok(await this.areaService.BorrarAreaAsync(areaId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }

        [HttpPut("{areaId}")]
        public async Task<ActionResult<Area>> Update(int areaId, [FromBody] Area area)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var areaUpdated = await this.areaService.ActualizarAreaAsync(areaId, area);
                return Ok(areaUpdated);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Something bad happened: {ex.Message}");
            }
        }
    }
}
