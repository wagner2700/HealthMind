using AutoMapper;
using HelthMind2.Dtos;
using HelthMind2.Model;

namespace HelthMind2.Profiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            CreateMap<CreateMedicoDto, MedicoModel>();
        }
    }
}
