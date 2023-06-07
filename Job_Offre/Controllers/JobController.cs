using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.JobRepository;
using Job_Offre.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Job_Offre.Controllers
{
    [ApiController]
    [Authorize("")]
    [Route("api/Job")]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;
        private readonly I_JobRepository _jobRepository;
        private readonly IMapper _mapper;

        public JobController(ILogger<JobController> Logger, I_JobRepository JobRepository, IMapper mapper)
        {
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _jobRepository = JobRepository ?? throw new ArgumentNullException(nameof(JobRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        [HttpGet()]
        [Route("GetJob")]
        public async Task<ActionResult<IEnumerable<JobDto>>> GetJob()
        {
            var job = await _jobRepository.GetJobsAsync();
            return Ok(_mapper.Map<IEnumerable<JobDto>>(job));
        }

        [HttpGet("{JobCode}", Name = "GetJobByJobCode")]
        public async Task<ActionResult<JobDto>> GetJobByJobCode(int JobCode)
        {
            var job = await _jobRepository.GetJobsByJobCodeAsync(JobCode);

            if(job == null)
            {
                return NotFound(); // 404
            }

            return Ok(_mapper.Map<JobDto>(job));//code 200
        }

        [HttpPost]
        [Route("CreateJob")]
        public async Task<ActionResult<JobDto>> CreateJob([FromBody]JobDto job)
        {
            try
            {  
                var Job = _mapper.Map<TmJobJob>(job);
                var jobExist = await _jobRepository.GetJobsByJobCodeAsync(job.JobCode);
                if(jobExist != null)
                {
                    _logger.LogInformation($"-->Le job {jobExist.JobName} existe déja");
                    throw new Exception("-->This job already exists !");
                }

                await _jobRepository.AddJobAsync(Job);
                await _jobRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }
            return CreatedAtRoute("GetJobByJobCode", new {job.JobCode}, job); // code 201
        }
    }
}
