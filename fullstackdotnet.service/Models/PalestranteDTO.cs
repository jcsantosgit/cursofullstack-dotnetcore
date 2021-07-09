using System.Collections.Generic;

namespace fullstackdotnet.service.Models
{
    public class PalestranteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MiniCurriculo { get; set; }
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }
        public List<PalestranteEventoDTO> PalestrantesEventos { get; set; }        
    }
}