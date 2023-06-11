using AutoMapper;
namespace Job_Offre.Profiles
{
    public class ProfileCandidate : Profile
    {
        public ProfileCandidate()
        {
            CreateMap<Entities.TmCndCandidate , Models.CandidateDto>();
        }
    }
}
