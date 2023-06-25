using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.ProfileDto;
using Job_Offre.Models.Dtos.RegionDtos;

namespace Job_Offre.Profiles
{
    public class ProfileRegion : Profile
    {
        public ProfileRegion()
        {    
            CreateMap<TmRegRegion, RegionReadDto>();
        }
    }
}
