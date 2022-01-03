using AutoMapper;
using Destino_Certo.Data.Dtos.Colaborador;
using Destino_Certo.Models;

namespace Destino_Certo.Data.Profiles
{
    public class ColaboradorProfile:Profile
    {
        public ColaboradorProfile()
        {
            CreateMap<CreateColaboradorDto, ColaboradorModel>();
            CreateMap<ColaboradorModel, ReadColaboradorDto>();
            CreateMap<UpdateColaboradorDto, ColaboradorModel>();
        }
    }
}
