using AutoMapper;
using Job_Offre.Models;
using Job_Offre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Job_Offre.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/candidateInfo")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CandidateController(ILogger<CandidateController> Logger, IUserRepository UserRepository, IMapper mapper)
        {
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _userRepository = UserRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidate()
        {
            var cnd = await _userRepository.GetCandidatesAsync();
            return Ok(_mapper.Map<IEnumerable<CandidateDto>>(cnd));
        }
    }
}
