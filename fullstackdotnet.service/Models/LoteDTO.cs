using System;
using System.Collections.Generic;
using fullstackdotnet.domain;

namespace fullstackdotnet.service.Models
{
    public class LoteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DateInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public EventoDTO Evento { get; set; }   

        public static Lote ParseToEntity(LoteDTO model)
        {
            try
            {
                Lote entity = new Lote();
                entity.Id = model.Id;
                entity.Nome = model.Nome;
                entity.Preco = model.Preco;
                entity.DateInicio = model.DateInicio;
                entity.DataFim = model.DataFim;
                entity.Quantidade = model.Quantidade;
                entity.EventoId = model.EventoId;
                
                if(model.Evento != null)
                    entity.Evento = EventoDTO.ParseToEntity(model.Evento);
                
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public static List<Lote> ParseToEntities(List<LoteDTO> models)
        {
            try
            {
                List<Lote> entities = new List<Lote>();
                foreach (var model in models)
                {
                    entities.Add(LoteDTO.ParseToEntity(model));
                }
                return entities;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }
    }
}