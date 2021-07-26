using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace fullstackdotnet.service.Models
{
    public class EventoFile
    {
        public string Name { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}