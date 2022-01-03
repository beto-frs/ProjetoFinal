using AutoMapper;
using Destino_Certo.Data.Dtos.Usuario.Admin;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class AdminProfile:Profile
    {
        public AdminProfile()
        {
            CreateMap<CreateAdminDto, UsuarioModel>();                
            CreateMap<UsuarioModel, ReadAdminDto>();
            CreateMap<UpdateAdminDto, UsuarioModel>();
        }
        
       
    }
}
