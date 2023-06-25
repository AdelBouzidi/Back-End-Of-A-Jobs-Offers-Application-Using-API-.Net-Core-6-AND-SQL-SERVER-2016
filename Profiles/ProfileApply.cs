using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.ApplyDtos;
using Job_Offre.Models.Dtos.ProfileDto;

namespace Job_Offre.Profiles
{
    public class ProfileApply : Profile
    {
        public ProfileApply()
        {
            CreateMap<ApplyDtoCreate, TrAppApply>();
            CreateMap<TrAppApply, ApplyDtoCreate>();
        }
    }
}
