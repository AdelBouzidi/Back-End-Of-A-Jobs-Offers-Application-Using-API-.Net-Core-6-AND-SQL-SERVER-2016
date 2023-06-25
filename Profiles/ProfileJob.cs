using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.JobDtos;

namespace Job_Offre.Profiles
{
    public class ProfileJob : Profile
    {
        public ProfileJob()
        {
            CreateMap<Entities.TmJobJob, Models.JobDto>();
            CreateMap<Models.JobDto, Entities.TmJobJob>();
            CreateMap<Models.JobCreateDto, Entities.TmJobJob>();

            CreateMap<JobDtoCreate, TmJobJob>();
            CreateMap<TmJobJob, JobDtoCreate>();

        }
    }
}
