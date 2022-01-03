using AutoMapper;
using Destino_Certo.Data.Dtos.Destino;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class DestinoProfile:Profile
    {
        public DestinoProfile()
        {
            CreateMap<CreateDestinoDto, DestinoModel>();
            CreateMap<DestinoModel, ReadDestinoDto>();
            CreateMap<UpdateDestinoDto, DestinoModel>();
        }
    }
}
