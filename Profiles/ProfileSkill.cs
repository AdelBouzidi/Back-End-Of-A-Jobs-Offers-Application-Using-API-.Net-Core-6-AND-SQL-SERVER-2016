using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.SkillDtos;

namespace Job_Offre.Profiles
{
    public class ProfileSkill : Profile
    {
        public ProfileSkill()
        {
            CreateMap<TmSklSkill, SkillReadDto>();
            CreateMap<SkillReadDto, TmSklSkill>();
            CreateMap<SkillDtoTransformed, SkillDtoTransformed2>();
        }
    }
}
