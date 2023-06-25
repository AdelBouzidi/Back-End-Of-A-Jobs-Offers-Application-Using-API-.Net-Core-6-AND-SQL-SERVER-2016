using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.RecruiterDtos;
using Job_Offre.Models.Dtos.UserDto.UserDtos;
using Job_Offre.Reduces;
using Job_Offre.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Job_Offre.Controllers
{
    [Route("api/Recruiter")]
    [ApiController]
    public class RecruiterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserReduce _userReduce;
        private readonly ILogger<RecruiterController> _logger;
        private readonly IUserRepository _userRepository;

        public RecruiterController(ILogger<RecruiterController> Logger, 
            IUserRepository UserRepository, IMapper mapper, IUserReduce UserReduce)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userReduce = UserReduce;
            _logger = Logger;
            _userRepository = UserRepository;
        }
        [HttpGet("{RecruiterEmail}", Name = "GetRecruiterByEmail")]
        public async Task<ActionResult<RecruiterReadDto>> GetRecruiterByMail(string RecruiterEmail)
        {
            //var usr = await _userRepository.RecruiterExistAsync(RecruiterEmail);
            var usr = await _userRepository.GetRecruiterByAdressMail(RecruiterEmail);
            return Ok(_mapper.Map<RecruiterReadDto>(usr));
        }

        [HttpPost]
        [Route("CreateRecruiter")]
        public async Task<ActionResult<RecruiterReadDto>> createRecruiter([FromBody] RecruiterCreate recruiterCreate)
        {
            var createUsr = new UserCreate();
            createUsr.UserName = recruiterCreate.RecruiterAdress;
            createUsr.UserPw = recruiterCreate.UserPw;
            createUsr.RoleCode = 1;
            var utilisateurCree = await _userReduce.CreateUser(createUsr);


            var createRecruiter = new RecruiterCreateDto();
            createRecruiter.RecruiterFname = recruiterCreate.RecruiterFname;
            createRecruiter.RecruiterLname = recruiterCreate.RecruiterLname;
            createRecruiter.RecruiterPhone = recruiterCreate.RecruiterPhone;
            createRecruiter.RecruiterDesc = recruiterCreate.RecruiterDesc;
            createRecruiter.RecruiterAdress = recruiterCreate.RecruiterAdress;
            createRecruiter.GenderCode = recruiterCreate.GenderCode;
            var userCodeRecruiter = utilisateurCree.UserCode;
            createRecruiter.UserCode = userCodeRecruiter;

            var Rec = _mapper.Map<TmRecRecruiter>(createRecruiter);

            var recruiterExist = await _userRepository.RecruiterExistAsync(Rec.RecruiterAdress);
            if (recruiterExist)
            {
                _logger.LogInformation($"-->ce recruiter existe deja");
                throw new Exception("-->This recruiter acount already exists !");
            }

            await _userRepository.AddRecruiterAsync(Rec);
            await _userRepository.SaveChangesAsync();
            //return CreatedAtAction("GetRecruiterByEmail", new { recruiterCreate.RecruiterAdress }, recruiterCreate); // code 201
            return await GetRecruiterByMailMethode(recruiterCreate.RecruiterAdress);
        }

        private async Task<RecruiterReadDto> GetRecruiterByMailMethode(string RecruiterEmail)
        {
            var usr = await _userRepository.GetRecruiterByAdressMail(RecruiterEmail);
            return _mapper.Map<RecruiterReadDto>(usr);
        }
    }
}
