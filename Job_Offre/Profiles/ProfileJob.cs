using AutoMapper;
namespace Job_Offre.Profiles
{
    public class ProfileJob : Profile
    {
        public ProfileJob()
        {
            CreateMap<Entities.TmJobJob, Models.JobDto>();
            CreateMap<Models.JobDto, Entities.TmJobJob>();
            CreateMap<Models.JobCreateDto, Entities.TmJobJob>();
        }
    }
}
