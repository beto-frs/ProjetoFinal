using AutoMapper;
using Destino_Certo.Data.Dtos.Pessoa;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class PessoaProfile:Profile
    {
        public PessoaProfile()
        {
            CreateMap<CreatePessoaDto, PessoaModel>();                
            CreateMap<PessoaModel, ReadPessoaDto>();
            CreateMap<UpdatePessoaDto, PessoaModel>();
        }
        
       
    }
}
