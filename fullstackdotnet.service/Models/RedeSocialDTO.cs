using System;
using System.Collections.Generic;
using fullstackdotnet.domain;

namespace fullstackdotnet.service.Models
{
    public class RedeSocialDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
        public int? EventoId { get; set; }
        public EventoDTO Evento { get; set; }
        public int? PalestranteId { get; set; }
        public PalestranteDTO Palestrante { get; set; }

        public static RedeSocial ParseToEntity(RedeSocialDTO model)
        {
            try
            {
                RedeSocial entity = new RedeSocial();
                entity.Id = model.Id;
                entity.Nome = model.Nome;
                entity.Url = model.Url;
                entity.EventoId = model .EventoId;
                if(model.Evento != null)
                    entity.Evento = EventoDTO.ParseToEntity(model.Evento);
                
                entity.PalestranteId = model.PalestranteId;
                
                if(model.Palestrante != null)
                entity.Palestrante = PalestranteDTO.ParseToEntity(model.Palestrante);
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<RedeSocial> ParseToEntities(List<RedeSocialDTO> models)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}