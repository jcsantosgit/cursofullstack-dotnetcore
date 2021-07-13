using System;
using System.Linq;
using System.Threading.Tasks;
using fullstackdotnet.domain;
using fullstackdotnet.repository;
using fullstackdotnet.service.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fullstackdotnet.service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private IFullstackRepository _repository;

        public EventoController(IFullstackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List(bool includePalestrantes)
        {
            try
            {
                var query = await _repository.GetAllEventoAsync(includePalestrantes);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("get-by-tema/{tema}/{incluirPalestrante}")]
        public async Task<IActionResult> GetByTema(string tema, bool incluirPalestrante)
        {
                var query = await _repository.GetAllEventoByTemaAsync(tema, incluirPalestrante);
                return Ok(query);
        }

        [HttpGet("{id}/{incluirPalestrante}")]
        public async Task<IActionResult> GetById(int id, bool incluirPalestrante)
        {
                var query = await _repository.GetEventoByIdAsync(id, incluirPalestrante);
                return Ok(query);            
        }

        [HttpPost]
        public async Task<IActionResult> Create(EventoDTO model)
        {
            try
            {
                var entity = model.GetEntityInstance();
                _repository.Add<Evento>(entity);

                if(await _repository.SaveChangesAsync())
                {
                    model.Id = entity.Id;
                    return Created($"api/evento/{entity.Id}/{false}", model);
                }

                return BadRequest("Recurso não encontrado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(int id, EventoDTO model)
        {
            try
            {
                var tmp = _repository.GetEventoByIdAsync(id);
                if(tmp == null) return NotFound("ID não encontrado");

                var entity = model.GetEntityInstance();
                entity.Id = tmp.Id;
                _repository.Update<Evento>(entity);

                if(await _repository.SaveChangesAsync())
                {
                    model.Id = entity.Id;
                    return Created($"api/evento/{entity.Id}/{false}", model);
                }
                
                return BadRequest("Recurso não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var entity = _repository.GetEventoByIdAsync(id);
                if(entity == null) NotFound("ID não encontado");
                _repository.Delete(entity);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}