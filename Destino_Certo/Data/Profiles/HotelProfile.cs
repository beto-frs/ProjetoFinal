using AutoMapper;
using Destino_Certo.Data.Dtos.Hotel;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class HotelProfile:Profile
    {
        public HotelProfile()
        {
            CreateMap<CreateHotelDto, HotelModel>();
            CreateMap<HotelModel, ReadHotelDto>();
            CreateMap<UpdateHotelDto, HotelModel>();
        }
    }
}
