using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.JobRepository;
using Job_Offre.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Job_Offre.Controllers
{
    [ApiController]
    [Route("api/User")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly I_JobRepository _jobRepository;

        public UserController(ILogger<UserController> Logger, I_JobRepository JobRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _jobRepository = JobRepository ?? throw new ArgumentNullException(nameof(JobRepository));
        }
        [HttpGet("{adressMail}/{role}")]
        public async Task<ActionResult<userDto>> GetUser(string adressMail, int role)
        {
            if(role != 1 && role != 2)
            {
                return NotFound();
            }
            if(role == 1)
            {
                var usr = await _jobRepository.GetRecruiterByEmail(adressMail);
                return Ok(_mapper.Map<userDto>(usr));
            }
            if (role == 2)
            {
                var usr = await _jobRepository.GetCandidateByEmail(adressMail);
                return Ok(_mapper.Map<userDto>(usr));
            }
            return NotFound();
        }
    }
}
