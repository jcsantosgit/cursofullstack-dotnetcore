using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace fullstackdotnet.service.Controllers
{
    public class FileManagerController : ControllerBase
    {
        public IActionResult Upload(IFormFile file)
        {
            try
            {
                var filePath  = Path.Combine(Directory.GetCurrentDirectory(),"");
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}