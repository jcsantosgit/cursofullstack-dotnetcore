namespace fullstackdotnet.service.Models
{
    public class PalestranteEventoDTO
    {
        public int Id { get; set; }
        public int PalestranteId { get; set; }
        public PalestranteDTO Palestrante { get; set; }
        public int EventoId { get; set; }
        public EventoDTO Evento { get; set; }        
    }
}