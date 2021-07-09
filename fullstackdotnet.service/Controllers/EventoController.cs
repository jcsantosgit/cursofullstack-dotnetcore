using System;
using fullstackdotnet.service.Models;
using Microsoft.AspNetCore.Mvc;

namespace fullstackdotnet.service.Controllers
{
    public class EventoController : ControllerBase
    {
        [HttpGet]
        public IActionResult List()
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