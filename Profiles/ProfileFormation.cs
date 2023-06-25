using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;

namespace Job_Offre.Profiles
{
    public class ProfileFormation : Profile
    {
        public ProfileFormation()
        {
            CreateMap<TmFrmFormation, FormationReadDto>(); 
            CreateMap<FormationDtoTransformed, FormationDtoTransformed2>();
            CreateMap<FormationReadDto, TmFrmFormation>();
        }
    }
}
