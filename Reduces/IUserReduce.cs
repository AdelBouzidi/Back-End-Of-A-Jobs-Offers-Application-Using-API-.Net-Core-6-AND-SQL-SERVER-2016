using Job_Offre.Entities;
using Job_Offre.Models.Dtos.UserDto.UserDtos;
using Job_Offre.Models.Dtos.UserDtos;

namespace Job_Offre.Reduces
{
    public interface IUserReduce
    {
        Task<UserReadDto> CreateUser(UserCreate userCreate);
    }
}