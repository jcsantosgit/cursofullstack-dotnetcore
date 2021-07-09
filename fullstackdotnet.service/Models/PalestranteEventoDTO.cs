using System;
using System.Collections.Generic;
using fullstackdotnet.domain;

namespace fullstackdotnet.service.Models
{
    public class PalestranteEventoDTO
    {
        public int Id { get; set; }
        public int PalestranteId { get; set; }
        public PalestranteDTO Palestrante { get; set; }
        public int EventoId { get; set; }
        public EventoDTO Evento { get; set; }

        public static PalestranteEvento ParseToEntity(PalestranteEventoDTO model)
        {
            try
            {
                PalestranteEvento entity = new PalestranteEvento();
                entity.Id = model.Id;
                entity.PalestranteId = model.PalestranteId;
                
                if(model.Palestrante != null)
                    entity.Palestrante = PalestranteDTO.ParseToEntity(model.Palestrante);

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

        internal static List<PalestranteEvento> ParseToEntities(List<PalestranteEventoDTO> models)
        {
            try
            {
                List<PalestranteEvento> entities = new List<PalestranteEvento>();
                foreach (var model in models)
                {
                    entities.Add(PalestranteEventoDTO.ParseToEntity(model));
                }
                return entities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}