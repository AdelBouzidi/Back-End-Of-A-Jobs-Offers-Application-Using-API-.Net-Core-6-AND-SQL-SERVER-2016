using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.CandidateDtos;
using Job_Offre.Models.Dtos.RecruiterDtos;

namespace Job_Offre.Profiles
{
    public class ProfileCandidate : Profile
    {
        public ProfileCandidate()
        {
            CreateMap<Entities.TmCndCandidate , Models.CandidateDto>();
            CreateMap<CandidateCreateDto, TmCndCandidate>();
            CreateMap<TmCndCandidate, CandidateReadDto>();
        }
    }
}
