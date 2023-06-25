using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.UserDto.UserDtos;
using Job_Offre.Models.Dtos.UserDtos;
using Job_Offre.Repositories;
using System.Text;

namespace Job_Offre.Reduces
{
    public class UserReduce : IUserReduce
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserReduce(IMapper mapper, IUserRepository UserRepository)
        {
            _mapper = mapper;
            _userRepository = UserRepository;
        }
        public async Task<UserReadDto> CreateUser(UserCreate userCreate)
        {
            var userCreateDto = new UserCreateDto();
            userCreateDto.UserPw = Encoding.ASCII.GetBytes(userCreate.UserPw);
            userCreateDto.UserName = userCreate.UserName;
            userCreateDto.RoleCode = userCreate.RoleCode;


            var user = _mapper.Map<TmUsrUserAccount>(userCreateDto);
            await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();

            var userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }
    }
}
