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

        // -----------------------------------
        // LEITURA
        // -----------------------------------

        [HttpGet("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                var query = await _repository.GetAllEventoAsync(false);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("search-by-title/{title}")]
        public async Task<IActionResult> SearchByTitle(string title)
        {
                var query = await _repository.GetAllEventoByTemaAsync(title, false);
                return Ok(query);
        }

        [HttpGet("search-by-id/{id}")]
        public async Task<IActionResult> SearchByCode(int id)
        {
                var query = await _repository.GetEventoByIdAsync(id, false);
                return Ok(query);            
        }

        // -----------------------------------
        // ESCRIA E ALTERAÇÃO
        // -----------------------------------
        [HttpPost("create")]
        public async Task<IActionResult> Create(EventoDTO model)
        {
            try
            {
                var entity = model.GetEntityInstance();
                _repository.Add<Evento>(entity);

                if(await _repository.SaveChangesAsync())
                {
                    model.Id = entity.Id;
                    return Created("/evento/{entity.Id}", model);
                }

                return BadRequest("Recurso não encontrado");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(EventoDTO model)
        {
            try
            {
                // var tmp = _repository.GetEventoByIdAsync(model.Id, false);
                // if(tmp == null) return NotFound("ID não encontrado");

                var entity = model.GetEntityInstance();
                _repository.Update<Evento>(entity);

                if(await _repository.SaveChangesAsync())
                {
                    model.Id = entity.Id;
                    return Created("/evento/{entity.Id}", model);
                }
                
                return BadRequest("Recurso não encontrado");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                // var entity = _repository.GetEventoByIdAsync(id);
                // if(entity == null) NotFound("ID não encontado");
                _repository.Delete<Evento>(new Evento { Id = id});
                
                if(await _repository.SaveChangesAsync()) Ok("Sucesso!");

                return BadRequest("Não foi possível excluir o Evento");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}