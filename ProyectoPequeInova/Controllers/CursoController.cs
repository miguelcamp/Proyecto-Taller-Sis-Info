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
    [Route("api/area/{areaId:int}/cursos")]

    public class CursoController : ControllerBase
    {
        private ICursoService cursoService;

        public CursoController(ICursoService cursoService)
        {
            this.cursoService = cursoService;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Curso>>> getCursoes(int artistaId)
        {
            try
            {
                return Ok(await cursoService.ObtenerCurso(artistaId));
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost()]
        public async Task<ActionResult<Curso>> PostCurso(int artistaId, [FromBody] Curso Curso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newSonge = await cursoService.AñadirCursoAsync(artistaId, Curso);
                return Created($"/api/artista/{artistaId}/Cursoes/{Curso.Id}", newSonge);
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

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Curso>> getCurso(int artistaId, int id)
        {
            try
            {
                var songe = await cursoService.ObtenerCursoAsync(artistaId, id);
                return Ok(songe);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{CursoId:int}")]
        public async Task<ActionResult<bool>> DeleteCurso(int CursoId, int artistaId)
        {
            try
            {
                var NoMoreSonge = await cursoService.EliminarCurso(artistaId, CursoId);
                return Ok(NoMoreSonge);
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



        [HttpPut("{CursoId:int}")]
        public async Task<ActionResult<Curso>> PutCurso(int artistaId, int CursoId, [FromBody] Curso Curso)
        {
            try
            {
                return Ok(await cursoService.ActualizarCursoAsync(artistaId, CursoId, Curso));
            }
            catch
            {
                throw new Exception("Not possible to show");
            }
        }
        
    }
}
