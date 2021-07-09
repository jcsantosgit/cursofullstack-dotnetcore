using System;
using System.Linq;
using fullstackdotnet.repository;
using fullstackdotnet.service.Models;
using Microsoft.AspNetCore.Mvc;

namespace fullstackdotnet.service.Controllers
{
    public class EventoController : ControllerBase
    {
        private FullstackDataContext _dbContext;

        public EventoController(FullstackDataContext dbContext)
        {
            _dbContext = dbContext;    
        }

        [HttpGet]
        public IActionResult List()
        {
            try
            {
                var query = _dbContext.Eventos.ToList();
                return Ok(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public IActionResult Create(EventoDTO model)
        {
            try
            {
                var entity = model.GetEntityInstance();
                _dbContext.Eventos.Add(entity);                
                return Ok("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public IActionResult Update(EventoDTO model)
        {
            try
            {
                var entity = model.GetEntityInstance();
                _dbContext.Eventos.Add(entity);
                return Ok("Success");
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
                return Ok("Success");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}