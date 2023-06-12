using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.RecruiterDtos;

namespace Job_Offre.Profiles
{
    public class ProfileRecruiter : Profile
    {
        public ProfileRecruiter()
        {
            CreateMap<RecruiterCreateDto,TmRecRecruiter>();
            CreateMap<TmRecRecruiter, RecruiterReadDto>();
        }
    }
}
