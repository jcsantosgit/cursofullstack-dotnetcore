using System;
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
    public class PalestranteController : ControllerBase
    {
        private IFullstackRepository _repository;

        public PalestranteController(IFullstackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> List(bool includeEventos = false)
        {
            try
            {
                var query = await _repository.GetAllPalestranteAsync(includeEventos);
                return Ok(query);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}/{includeEventos}")]
        public async Task<IActionResult> SearchById(int id, bool includeEventos = false)
        {
            try
            {
                var query = await _repository.GetPalestranteByIdAsync(id, includeEventos);
                return Ok(query);
            }
            catch (Exception ex)
            {               
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(PalestranteDTO model)
        {
            try
            {
                var entity = PalestranteDTO.ParseToEntity(model);
                _repository.Add<Palestrante>(entity);
                if(await _repository.SaveChangesAsync())
                {
                    model.Id = entity.Id;
                    return Created($"api/palestrante/{entity.Id}/{false}", model);
                }

                return BadRequest("Não foi possível salvar o Palestrante");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(PalestranteDTO model)
        {
            try
            {
                var entity = PalestranteDTO.ParseToEntity(model);
                _repository.Update<Palestrante>(entity);
                if(await _repository.SaveChangesAsync())
                {
                    model.Id = entity.Id;
                    return Created($"api/palestrante/{entity.Id}/{false}", model);
                }

                return BadRequest("Não foi possível salvar o Palestrante");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        public async Task<IActionResult> Delete(int id)    
        {
            try
            {
                _repository.Delete<Palestrante>(new Palestrante{ Id = id });
                if(await _repository.SaveChangesAsync())
                    return Ok("Excluido com sucesso!");
                
                return BadRequest("Não foi possível excluir!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}