using AutoMapper;
using Destino_Certo.Data.Dtos.Atendimento;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class AtendimentoProfile:Profile
    {
        public AtendimentoProfile()
        {
            CreateMap<CreateAtendimentoDto, AtendimentoModel>();                
            CreateMap<AtendimentoModel, ReadAtendimentoDto>();
            CreateMap<UpdateAtendimentoDto, AtendimentoModel>();
        }
        
       
    }
}
