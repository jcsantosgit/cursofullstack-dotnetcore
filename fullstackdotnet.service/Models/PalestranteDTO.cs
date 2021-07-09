using System;
using System.Collections.Generic;
using fullstackdotnet.domain;

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

        internal static Palestrante ParseToEntity(PalestranteDTO model)
        {
            try
            {
                Palestrante entity = new Palestrante();
                entity.Id = model.Id;
                entity.Nome = model.Nome;
                entity.MiniCurriculo = entity.MiniCurriculo;
                entity.ImageUrl = model.ImageUrl;
                entity.Telefone = model.Telefone;
                entity.Email = model.Email;
                if(model.RedesSociais != null)
                    entity.RedesSociais = RedeSocialDTO.ParseToEntities(model.RedesSociais);
                
                if(model.PalestrantesEventos != null)
                    entity.PalestrantesEventos = PalestranteEventoDTO.ParseToEntities(model.PalestrantesEventos);
                
                return entity;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}