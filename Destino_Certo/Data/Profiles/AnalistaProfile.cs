using AutoMapper;
using Destino_Certo.Data.Dtos.Usuario.Analista;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class AnalistaProfile:Profile
    {
        public AnalistaProfile()
        {
            CreateMap<CreateAnalistaDto, UsuarioModel>();                            
            CreateMap<UsuarioModel, ReadAnalistaDto>();
            CreateMap<UpdateAnalistaDto, UsuarioModel>();
        }
        
       
    }
}
