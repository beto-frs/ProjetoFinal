using AutoMapper;
using Destino_Certo.Data.Dtos.Usuario.User;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class UsuarioProfile:Profile
    {
        public UsuarioProfile()
        {               
            CreateMap<CreateUserDto, UsuarioModel>();
            CreateMap<UsuarioModel, ReadUserDto>();
            CreateMap<UpdateUserDto, UsuarioModel>();
        }
        
       
    }
}
