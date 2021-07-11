using System.Collections.Generic;

namespace fullstackdotnet.domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int MiniCurriculo { get; set; }
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public List<RedeSocial> RedesSociais { get; set; }
        public List<PalestranteEvento> PalestrantesEventos { get; set; }
    }
}