using System;
using System.Collections.Generic;

namespace fullstackdotnet.service.Models
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPublico { get; set; }
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<LoteDTO> Lotes { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }
        public List<PalestranteEventoDTO> PalestrantesEventos { get; set; }        
    }
}