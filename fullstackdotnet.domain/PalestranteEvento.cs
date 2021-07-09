namespace fullstackdotnet.domain
{
    public class PalestranteEvento
    {
        public int Id { get; set; }
        public int PalestranteId { get; set; }
        public Palestrante Palestrante { get; set; }
        public int EventoId { get; set; }
        public Evento Evento { get; set; }
    }
}