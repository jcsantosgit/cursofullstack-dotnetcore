using System;
using System.Collections.Generic;
using fullstackdotnet.domain;

namespace fullstackdotnet.service.Models
{
    public class EventoDTO
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public DateTime? DataEvento { get; set; }
        public string Tema { get; set; }
        public int QtdPublico { get; set; }
        public string ImageUrl { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Conteudo { get; set; }
        public List<LoteDTO> Lotes { get; set; }
        public List<RedeSocialDTO> RedesSociais { get; set; }
        public List<PalestranteEventoDTO> PalestrantesEventos { get; set; }

        public bool IncludePalestrantes { get; set; }

        public Evento GetEntityInstance()
        {
            try
            {
                return EventoDTO.ParseToEntity(this);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Evento ParseToEntity(EventoDTO model)
        {
            try
            {
                Evento entity = new Evento();
                entity.Id = model.Id;
                entity.Local = model.Local;
                entity.DataEvento = model.DataEvento.Value;
                entity.Tema = model.Tema;
                entity.QtdPublico = model.QtdPublico;
                entity.ImageUrl = model.ImageUrl;
                entity.Telefone = model.Telefone;
                entity.Email = model.Email;

                if(model.Lotes != null)
                    entity.Lotes = LoteDTO.ParseToEntities(model.Lotes);
                
                if(model.RedesSociais != null)
                    entity.RedesSociais = RedeSocialDTO.ParseToEntities(model.RedesSociais);

                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}