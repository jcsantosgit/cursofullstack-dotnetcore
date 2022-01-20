using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using fullstackdotnet.service.Models;

namespace fullstackdotnet.service.Controllers
{
    [Route("[controller]")]
    public class FileManagerController : ControllerBase
    {
        private IWebHostEnvironment _environment;

        public FileManagerController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if(file == null) BadRequest("Arquivo(s) invalido(s)");

                if(file == null) return BadRequest("Arquivo invalido");

                byte[] bytes = ConvertFileInByteArray(file);

                string fileName = string.Format("evento_{0}", DateTime.Now.Millisecond);
                string filePath  = Path.Combine(Directory.GetCurrentDirectory(),"Images", fileName);
                
                await System.IO.File.WriteAllBytesAsync(filePath, bytes);                   

                return Ok(filePath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] ConvertFileInByteArray(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }        
    }
}