using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models;
using Job_Offre.Models.Dtos.CandidateDtos;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;
using Job_Offre.Models.Dtos.SkillDtos;
using Job_Offre.Models.Dtos.UserDto.UserDtos;
using Job_Offre.Models.Dtos.UserDtos;
using Job_Offre.Reduces;
using Job_Offre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Job_Offre.Models.Dtos.ProfileDto;

namespace Job_Offre.Controllers
{
    [ApiController]
    [Route("api/candidate")]
    public class CandidateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserReduce _userReduce;

        public CandidateController(ILogger<CandidateController> Logger, IUserRepository UserRepository, 
            IMapper mapper, IUserReduce UserReduce)
        {
            _logger = Logger ?? throw new ArgumentNullException(nameof(Logger));
            _userRepository = UserRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _userReduce = UserReduce;
        }
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<CandidateDto>>> GetCandidate()
        {
            var cnd = await _userRepository.GetCandidatesAsync();
            return Ok(_mapper.Map<IEnumerable<CandidateDto>>(cnd));
        }

        [HttpPost]
        [Route("CreateCandidate")]
        public async Task<ActionResult<CandidateReadDto>> createCandidate([FromBody] CandidateCreate candidateCreate)
        {
            var createUsr = new UserCreate();
            createUsr.UserName = candidateCreate.CandidateAdress;
            createUsr.UserPw = candidateCreate.UserPw;
            createUsr.RoleCode = 2;
            var utilisateurCree = await _userReduce.CreateUser(createUsr);

            var createCandidate = new CandidateCreateDto();
            createCandidate.CandidateFname = candidateCreate.CandidateFname;
            createCandidate.CandidateLname = candidateCreate.CandidateLname;
            createCandidate.CandidatePhone = candidateCreate.CandidatePhone;
            createCandidate.CandidateDesc = candidateCreate.CandidateDesc;
            createCandidate.CandidateAdress = candidateCreate.CandidateAdress;
            createCandidate.GenderCode = candidateCreate.GenderCode;
            createCandidate.CandidateMs = candidateCreate.CandidateMs;
            var userCodeRecruiter = utilisateurCree.UserCode;
            createCandidate.UserCode = userCodeRecruiter;

            var Cnd = _mapper.Map<TmCndCandidate>(createCandidate);

            var recruiterExist = await _userRepository.CandidateExistAsync(Cnd.CandidateAdress);
            if (recruiterExist)
            {
                _logger.LogInformation($"-->ce candidat existe deja");
                throw new Exception("-->This candidate acount already exists !");
            }

            await _userRepository.AddCandidateAsync(Cnd);
            await _userRepository.SaveChangesAsync();
            return await GetCandidateByMailMethode(candidateCreate.CandidateAdress);
        }

        private async Task<CandidateReadDto> GetCandidateByMailMethode(string RecruiterEmail)
        {
            var usr = await _userRepository.GetCandidateByAdressMail(RecruiterEmail);
            return _mapper.Map<CandidateReadDto>(usr);
        }

        [HttpGet()]
        [Route("GetCandidateByMail")]
        public async Task<ActionResult<CandidateReadDto>> GetCandidateByMail(string mail)
        {
            var usr = await _userRepository.GetCandidateByAdressMail(mail);
            return _mapper.Map<CandidateReadDto>(usr);
        }



        //[HttpGet()]
        //[Route("GetProfile")]
        //public async Task<ActionResult<object>> GetProfile(string mail)
        //{
        //    var exp = await GetCndExpByMailTest(mail);
        //    var form = GetCndFormByMailTest(mail);
        //    var skill = GetCndSkillByMailTest(mail);
        //    var pref = GetCndPrefByMailTest(mail);
        //    var profile = new ProfileDto
        //    {
        //        FormationDtoProfile = form,
        //        PreferenceDtoProfile = pref,
        //        ExperienceDtoProfile = exp,
        //        SkillDtoProfile = skill,
        //    };
        //    if (exp == null)
        //    {
        //        return NotFound();
        //    }

        //    //pour récupirer length de l'objet retourné par GetCandidateExp() :
        //    if (exp is IEnumerable<object> enumerableResult)
        //    {
        //        var count = enumerableResult.Cast<object>().Count();
        //        if (count > 1)
        //        {
        //            var exp2 = _mapper.Map<IEnumerable<ExperienceDtoTransformed2>>(exp);
        //            return Ok(exp2);
        //        }
        //    }
        //    var exp3 = _mapper.Map<ExperienceDtoTransformed2>(exp);
        //    return Ok(exp3);
        //}


        [HttpGet()]
        [Route("GetExpByMail")]
        public async Task<ActionResult<object>> GetCndExpByMail(string mail)
        {
            var exp = await _userRepository.GetCandidateExp(mail);
            if (exp == null)
            {
                return NotFound();
            }

            //pour récupirer length de l'objet retourné par GetCandidateExp() :
            if (exp is IEnumerable<object> enumerableResult)
            {
                var count = enumerableResult.Cast<object>().Count();
                if (count > 1)
                {
                    var exp2 = _mapper.Map<IEnumerable<ExperienceDtoTransformed2>>(exp);
                    return Ok(exp2);
                }
            }
            var exp3 = _mapper.Map<ExperienceDtoTransformed2>(exp);
            return Ok(exp3);
        }

        private async Task<object> GetCndExpByMailTest(string mail)
        {
            var exp = await _userRepository.GetCandidateExp(mail);
            if (exp == null)
            {
                return NotFound();
            }

            //pour récupirer length de l'objet retourné par GetCandidateExp() :
            if (exp is IEnumerable<object> enumerableResult)
            {
                var count = enumerableResult.Cast<object>().Count();
                if (count > 1)
                {
                    var exp2 = _mapper.Map<IEnumerable<ExperienceDtoTransformed2>>(exp);
                    return Ok(exp2);
                }
            }
            var exp3 = _mapper.Map<ExperienceDtoTransformed2>(exp);
            return Ok(exp3);
        }



        private async Task<string> getReginByCode(int regionCode)
        {
            var region = await _userRepository.GetRegionByCodeReg(regionCode);
            return region.RegionName;
        }
        private async Task<string> getCountryByCode(int countryCode)
        {
            var country = await _userRepository.GetCountryByCodeCot(countryCode);
            return country.CountryName;
        }
        private async Task<string> getSkillByCode(int skillCode)
        {
            var skill = await _userRepository.GetskillByCodeskill(skillCode);
            return skill.SkillName;
        }
        private async Task<string> getDomainByCode(int domainCode)
        {
            var domain = await _userRepository.GetDomainByCodesDom(domainCode);
            return domain.DomainName;
        }



        [HttpGet()]
        [Route("GetFormByMail")]
        public async Task<ActionResult<object>> GetCndFormByMail(string mail)
        {
            var form = await _userRepository.GetCandidateForm2(mail);
            if (form == null)
            {
                return NotFound();
            }

            if (form is IEnumerable<object> enumerableResult)
            {
                var count = enumerableResult.Cast<object>().Count();
                if (count > 1)
                {
                    var form2 = _mapper.Map<IEnumerable<FormationDtoTransformed2>>(form);
                    return Ok(form2);
                }
            }
            var form3 = _mapper.Map<FormationDtoTransformed2>(form);
            return Ok(form3);
        }

        private async Task<object> GetCndFormByMailTest(string mail)
        {
            var form = await _userRepository.GetCandidateForm2(mail);
            if (form == null)
            {
                return NotFound();
            }

            if (form is IEnumerable<object> enumerableResult)
            {
                var count = enumerableResult.Cast<object>().Count();
                if (count > 1)
                {
                    var form2 = _mapper.Map<IEnumerable<FormationDtoTransformed2>>(form);
                    return Ok(form2);
                }
            }
            var form3 = _mapper.Map<FormationDtoTransformed2>(form);
            return Ok(form3);
        }

        [HttpGet()]
        [Route("GetSkillByMail")]
        public async Task<ActionResult<object>> GetCndSkillByMail(string mail)
        {
            var skill = await _userRepository.GetCandidateSkill(mail);
            if (skill == null)
            {
                return NotFound();
            }

            if (skill is IEnumerable<object> enumerableResult)
            {
                var count = enumerableResult.Cast<object>().Count();
                if (count > 1)
                {
                    var skill2 = _mapper.Map<IEnumerable<SkillDtoTransformed2>>(skill);
                    return Ok(skill2);
                }
            }
            var skill3 = _mapper.Map<SkillDtoTransformed2>(skill);
            return Ok(skill3);
        }


        private async Task<object> GetCndSkillByMailTest(string mail)
        {
            var skill = await _userRepository.GetCandidateSkill(mail);
            if (skill == null)
            {
                return NotFound();
            }

            if (skill is IEnumerable<object> enumerableResult)
            {
                var count = enumerableResult.Cast<object>().Count();
                if (count > 1)
                {
                    var skill2 = _mapper.Map<IEnumerable<SkillDtoTransformed2>>(skill);
                    return Ok(skill2);
                }
            }
            var skill3 = _mapper.Map<SkillDtoTransformed2>(skill);
            return Ok(skill3);
        }



       

        [HttpGet()]
        [Route("GetPreferenceByMail")]
        public async Task<ActionResult<object>> GetCndPrefByMail(string mail)
        {
            var pref = await _userRepository.GetCandidatePref(mail);
            if (pref == null)
            {
                return NotFound();
            }
            var pref3 = _mapper.Map<PreferenceDtoTranformed2>(pref);
            return Ok(pref3);
        }

        private async Task<object> GetCndPrefByMailTest(string mail)
        {
            var pref = await _userRepository.GetCandidatePref(mail);
            if (pref == null)
            {
                return NotFound();
            }
            var pref3 = _mapper.Map<PreferenceDtoTranformed2>(pref);
            return Ok(pref3);
        }
    }
}
