using AutoMapper;

namespace Job_Offre.Profiles
{
    public class ProfileUser : Profile
    {
        public ProfileUser()
        {
            CreateMap<Entities.TmUsrUserAccount, Models.userDto>();
        }
    }
}
