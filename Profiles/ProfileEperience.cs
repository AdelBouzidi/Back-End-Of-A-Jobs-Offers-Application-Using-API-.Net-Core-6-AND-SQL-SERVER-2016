using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.CandidateDtos;
using Job_Offre.Models.Dtos.ExperienceDtos;

namespace Job_Offre.Profiles
{
    public class ProfileEperience : Profile
    {
        public ProfileEperience()
        {
            CreateMap<TmExpExperience, ExperienceReadDto>();
            CreateMap<ExperienceReadDto, TmExpExperience>();
            CreateMap<ExperienceDtoTransformed, ExperienceDtoTransformed2>();
            //CreateMap<ExperienceDtoCreate, ExperienceReadDto>(); 
            CreateMap<ExperienceDtoTransformed3, ExperienceDtoTransformed4>();

        }
    }
}
