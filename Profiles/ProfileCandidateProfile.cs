using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.CandidateDtos;
using Job_Offre.Models.Dtos.ProfileDto;

namespace Job_Offre.Profiles
{
    public class ProfileCandidateProfile : Profile
    {
        public ProfileCandidateProfile()
        {
            CreateMap<ProfleDtoCandidate, ProfleDtoCandidate2>();
        }
    }
}
