using AutoMapper;
using HelthMind2.Dtos;
using HelthMind2.Model;

namespace HelthMind2.Profiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            CreateMap<CreatePacienteDto, PacienteModel>();
            CreateMap<PacienteModel ,ReadPacienteDto>();
            CreateMap<UpdatePacienteDto, PacienteModel>();
        }
    }
}
