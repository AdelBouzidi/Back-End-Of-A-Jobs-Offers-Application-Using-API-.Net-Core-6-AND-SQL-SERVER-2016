using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;

namespace Job_Offre.Profiles
{
    public class ProfilePreference : Profile
    {
        public ProfilePreference()
        {
            CreateMap<TmPrfPreference, PreferenceReadDto>();
            CreateMap<PreferenceReadDto, TmPrfPreference>();
            CreateMap<PreferenceDtoTransformed, PreferenceDtoTranformed2>();
        }
    }
}
