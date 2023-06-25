using AutoMapper;
using Job_Offre.Models.Dtos.UserDto.UserDtos;
using Job_Offre.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Job_Offre.Repositories;
using Job_Offre.Reduces;

namespace Job_Offre.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserReduce _userReduce;
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepository _userRepository;

        public UserController(ILogger<UserController> Logger, IUserRepository UserRepository, 
            IMapper mapper, IUserReduce UserReduce)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userReduce = UserReduce;
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _userRepository = UserRepository;
        }
        [HttpGet("{adressMail}/{role}")]
        public async Task<ActionResult<UserReadDto>> GetUser(string adressMail, int role)
        {
            if (role != 1 && role != 2)
            {
                return NotFound();
            }
            if (role == 1)
            {
                var usr = await _userRepository.GetRecruiterByEmail(adressMail);
                return Ok(_mapper.Map<UserReadDto>(usr));
            }
            if (role == 2)
            {
                var usr = await _userRepository.GetCandidateByEmail(adressMail);
                return Ok(_mapper.Map<UserReadDto>(usr));
            }
            return NotFound();
        }


        [HttpPost()]
        [Route("CreateUserAsync")]
        public async Task<ActionResult<UserReadDto>> CreateUserAsync([FromBody] UserCreate userCreate)
        {
            try
            {
                var userReadDto = await _userReduce.CreateUser(userCreate);

                // ki yasra le mapp hada automatiquement le code ta3 lutilisateur li insiritou rah nalgah hna f userReadDto
                return CreatedAtAction(nameof(GetUserByCode), new { code = userReadDto.UserCode }, userReadDto);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
                throw new ArgumentNullException(nameof(ex));
            }
        }

        [HttpGet()]
        [Route("GetUserByCode")]
        public async Task<ActionResult<UserReadDto>> GetUserByCode(int codeUser)
        {
            var user = await _userRepository.GetUserByCode(codeUser);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpGet(Name = "GetMaxUser")]
        [HttpGet()]
        [Route("GetUserMax")]
        public async Task<ActionResult<UserReadDto>> GetUserMax()
        {
            var usr = await _userRepository.GetUserAsync();
            return Ok(_mapper.Map<UserReadDto>(usr));
        }

    }
}
