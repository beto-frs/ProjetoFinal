using AutoMapper;
using Destino_Certo.Data.Dtos.Reserva;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class ReservaProfile:Profile
    {
        public ReservaProfile()
        {
            CreateMap<CreateReservaDto, ReservaModel>();
            CreateMap<ReservaModel, ReadReservaDto>();
            CreateMap<UpdateReservaUsuarioDto, ReservaModel>();
        }

    }
}
