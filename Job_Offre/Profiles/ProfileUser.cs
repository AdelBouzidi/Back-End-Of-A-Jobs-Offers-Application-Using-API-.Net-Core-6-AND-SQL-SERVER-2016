using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.UserDtos;

namespace Job_Offre.Profiles
{
    public class ProfileUser : Profile
    {
        public ProfileUser()
        {
            CreateMap<TmUsrUserAccount, UserReadDto>();
            CreateMap<UserCreateDto, TmUsrUserAccount>();
            //CreateMap<UserReadDto, TmUsrUserAccount>();

        }
    }
}
