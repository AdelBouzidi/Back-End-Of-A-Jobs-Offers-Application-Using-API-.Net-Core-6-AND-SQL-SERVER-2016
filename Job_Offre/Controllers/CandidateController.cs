using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.JobRepository;
using Job_Offre.Models;
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
        private readonly I_JobRepository _jobRepository;
        private readonly IMapper _mapper;

        public CandidateController(ILogger<CandidateController> Logger, I_JobRepository JobRepository, IMapper mapper)
        {
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _jobRepository = JobRepository ?? throw new ArgumentNullException(nameof(JobRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetJob()
        {
            var cnd = await _jobRepository.GetCandidatesAsync();
            return Ok(_mapper.Map<IEnumerable<CandidateDto>>(cnd));
        }
    }
}
