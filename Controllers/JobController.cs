using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models;
using Job_Offre.Models.Dtos.JobDtos;
using Job_Offre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Job_Offre.Controllers
{
    [ApiController]
    //[Authorize("")]
    [Route("api/Job")]
    public class JobController : ControllerBase
    {
        private readonly ILogger<JobController> _logger;
        private readonly IJobRepository _jobRepository;
        private readonly IMapper _mapper;
        private readonly ICandidateProfileRepository _candidateProfileRepository;

        public JobController(ILogger<JobController> Logger, IJobRepository JobRepository, IMapper mapper,
            ICandidateProfileRepository candidateProfileRepository)
        {
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _jobRepository = JobRepository ?? throw new ArgumentNullException(nameof(JobRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _candidateProfileRepository = candidateProfileRepository;
        }
        //[HttpGet()]
        //[Route("GetJob")]
        //public async Task<ActionResult<IEnumerable<JobDto>>> GetJob()
        //{
        //    var job = await _jobRepository.GetJobsAsync();
        //    return Ok(_mapper.Map<IEnumerable<JobDto>>(job));
        //}
        [HttpGet()]
        [Route("GetJob")]
        public async Task<ActionResult<IEnumerable<JobDtoTransformed>>> GetJob()
        {
            var job = await _jobRepository.GetJobsTransformedAsync();
            return Ok(job);
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
        public async Task<ActionResult<JobDtoCreate>> CreateJob([FromBody] JobDtoCreateTransformed job)
        {
            try
            {   var regionCode = await _candidateProfileRepository.GetRegionCodeByRegionName(job.RegionName!);
                var job1 = new JobDtoCreate();
                job1.JobName = job.JobName;
                job1.JobDesc = job.JobDesc;
                job1.JobLevel = job.JobLevel;
                job1.JobExpDate = job.JobExpDate;
                job1.JobMode = job.JobMode;
                job1.DomainCode = job.DomainCode;
                job1.RegionCode = regionCode;
                job1.RecruiterCode = job.RecruiterCode;
                job1.CtrCode = job.CtrCode;
                job1.NumberOfPosts = job.NumberOfPosts;
                job1.YearExperienceRequired = job.YearExperienceRequired;
                job1.FrenchLevel = job.FrenchLevel;
                job1.EnglishLevel = job.EnglishLevel;
                job1.Graduate = job.Graduate;

                var jobExist = await _jobRepository.JobExist(job1);
                if(jobExist)
                {
                    _logger.LogInformation($"-->Le job {job.JobName} existe déja");
                    throw new Exception("-->This job already exists !");
                }
                var J = _mapper.Map<TmJobJob>(job1);
                await _jobRepository.AddJobAsync(J);
                await _jobRepository.SaveChangesAsync();
                //var jobToReturn = GetJobByCode(J.JobCode);
                //return Ok(_mapper.Map<JobDtoCreate>(jobToReturn));
                
                var jobToReturn = await GetJobByAllProp(job1);
                return Ok(_mapper.Map< JobDtoCreate >(jobToReturn));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }
            //return CreatedAtRoute("GetJobByJobCode", new {Job.JobCode}, job); // code 201
            throw new Exception("An error occurred while creating the job.");
        }

        private async Task<TmJobJob> GetJobByCode(int JobCode)
        {
            var job = await _jobRepository.GetJobsByJobCodeAsync(JobCode);
            return job;//code 200
        }
        private async Task<TmJobJob> GetJobByAllProp(JobDtoCreate job)
        {
            var j = await _jobRepository.GetJobByALLprop(job);
            return j;//code 200
        }


        [HttpGet()]
        [Route("GetJobByRecruiterCode")]
        public async Task<ActionResult<JobDtoCreateTransformed2>> GetJobByRecruiterCode(int recruiterCode)
        {
            var job = await _jobRepository.GetJobByRecruiterCode(recruiterCode);
           
            if (job == null)
            {
                return NotFound(); // 404
            }

            return Ok(job);//code 200
        }
    }
}
