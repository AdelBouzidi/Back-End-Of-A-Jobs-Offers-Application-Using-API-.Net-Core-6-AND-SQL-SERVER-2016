using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.JobRepository;
using Job_Offre.Models;
using Job_Offre.Models.Dtos.RecruiterDtos;
using Job_Offre.Models.Dtos.UserDto.UserDtos;
using Job_Offre.Models.Dtos.UserDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Text;

namespace Job_Offre.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IJobRepository _jobRepository;

        public UserController(ILogger<UserController> Logger, IJobRepository JobRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _jobRepository = JobRepository ?? throw new ArgumentNullException(nameof(JobRepository));
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
                var usr = await _jobRepository.GetRecruiterByEmail(adressMail);
                return Ok(_mapper.Map<UserReadDto>(usr));
            }
            if (role == 2)
            {
                var usr = await _jobRepository.GetCandidateByEmail(adressMail);
                return Ok(_mapper.Map<UserReadDto>(usr));
            }
            return NotFound();
        }

        [HttpGet(Name = "GetMaxUser")]
        [HttpGet()]
        [Route("GetUserMax")]
        public async Task<ActionResult<UserReadDto>> GetUserMax()
        {
            var usr = await _jobRepository.GetUserAsync();
            return Ok(_mapper.Map<UserReadDto>(usr));
        }

        [HttpGet("{RecruiterEmail}", Name = "GetRecruiterByEmail")]
        public async Task<ActionResult<RecruiterReadDto>> GetRecruiterByMail(string RecruiterEmail)
        {
            var usr = await _jobRepository.RecruiterExistAsync(RecruiterEmail);
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
            var utilisateurCree = await CreateUser(createUsr);


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

            var recruiterExist = await _jobRepository.RecruiterExistAsync(Rec.RecruiterAdress);
            if (recruiterExist )
            {
                _logger.LogInformation($"-->ce recruiter existe deja");
                throw new Exception("-->This recruiter acount already exists !");
            }

            await _jobRepository.AddRecruiterAsync(Rec);
            await _jobRepository.SaveChangesAsync();
            //return CreatedAtAction("GetRecruiterByEmail", new { recruiterCreate.RecruiterAdress }, recruiterCreate); // code 201
            return await GetRecruiterByMailMethode(recruiterCreate.RecruiterAdress);
        }
        private async Task<UserReadDto> CreateUser(UserCreate userCreate)
        {
            var userCreateDto = new UserCreateDto();
            userCreateDto.UserPw = Encoding.ASCII.GetBytes(userCreate.UserPw);
            userCreateDto.UserName = userCreate.UserName;
            userCreateDto.RoleCode = userCreate.RoleCode;


            var user = _mapper.Map<TmUsrUserAccount>(userCreateDto);
            await _jobRepository.AddUserAsync(user);
            await _jobRepository.SaveChangesAsync();

            var userReadDto = _mapper.Map<UserReadDto>(user);
            return userReadDto;
        }
        private async Task<RecruiterReadDto> GetRecruiterByMailMethode(string RecruiterEmail)
        {
            var usr = await _jobRepository.GetRecruiterByAdressMail(RecruiterEmail);
            return _mapper.Map<RecruiterReadDto>(usr);
        }

        [HttpPost()]
        [Route("CreateUserAsync")]
        public async Task<ActionResult<UserReadDto>> CreateUserAsync([FromBody] UserCreate userCreate)
        {
            try
            {
                var userReadDto = await CreateUser(userCreate);

                // ki yasra le mapp hada automatiquement le code ta3 lutilisateur li insiritou rah nalgah hna f userReadDto
                return CreatedAtAction(nameof(GetUserByCode), new {code = userReadDto.UserCode}, userReadDto);
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
            var user = await _jobRepository.GetUserByCode(codeUser);
            if (user == null)
            {
                return NotFound();
            }
          
            return Ok(_mapper.Map<UserReadDto>(user));
        }
    }
}
