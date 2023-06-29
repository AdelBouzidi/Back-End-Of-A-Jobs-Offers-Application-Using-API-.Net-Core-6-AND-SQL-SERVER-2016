using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models;
using Job_Offre.Models.Dtos.ApplyDtos;
using Job_Offre.Models.Dtos.CandidateDtos;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;
using Job_Offre.Models.Dtos.JobDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;
using Job_Offre.Models.Dtos.ProfileDto;
using Job_Offre.Models.Dtos.SkillDtos;
using Job_Offre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Emit;

namespace Job_Offre.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/profile")]
    public class ProfileCandiateController : ControllerBase
    {
        private readonly ILogger<CandidateController> _logger;
        private readonly ICandidateProfileRepository _candidateProfileRepository;
        private readonly IMapper _mapper;

        public ProfileCandiateController(ILogger<CandidateController> Logger,
            ICandidateProfileRepository candidateProfileRepository,
            IMapper mapper)
        {
            _logger = Logger;
            _candidateProfileRepository = candidateProfileRepository;
            _mapper = mapper;
        }

        [HttpGet()]
        [Route("GetProfileByMail")]
        public async Task<ActionResult<ProfileDtoCandidate3>> GetProfileByEmail(string mail)
        {
            var ex = 0;
            var fr = 0;
            var sk = 0;
            var pr = 0;
            var exp = await _candidateProfileRepository.GetCandidateExp(mail);
            var form = await _candidateProfileRepository.GetCandidateForm(mail);
            var skill = await _candidateProfileRepository.GetCandidateSkill(mail);
            var pref = await _candidateProfileRepository.GetCandidatePref(mail);

            if (skill.Any())
            {
                sk = 1;
            }
            if (form.Any())
            {
                fr = 1;
            }
            if (exp.Any())
            {
                ex = 1;
            }
            if (pref != null)
            {
                pr = 1;
            }

            if ((ex == 1 && fr == 0 && sk == 0 && pr == 0) ||
                (ex == 0 && fr == 1 && sk == 0 && pr == 0) ||
                (ex == 0 && fr == 0 && sk == 1 && pr == 0) ||
                (ex == 0 && fr == 0 && sk == 0 && pr == 1))
            {
                var prof = new ProfleDtoCandidate();
                prof.ExperienceProfile = exp;
                prof.FormationProfile = form;
                prof.PreferenceProfile = pref;
                prof.SkillProfile = skill;
                var prof2 = _mapper.Map<ProfleDtoCandidate2>(prof);
                var profil3 = new ProfileDtoCandidate3();
                profil3.pourcentageProfile = 25;
                profil3.ExperienceProfile = prof2.ExperienceProfile;
                profil3.FormationProfile = prof2.FormationProfile;
                profil3.PreferenceProfile = prof2.PreferenceProfile;
                profil3.SkillProfile = prof2.SkillProfile;
                return Ok(profil3);
            }
            else if ((ex == 1 && fr == 1 && sk == 0 && pr == 0) ||
                (ex == 1 && fr == 0 && sk == 1 && pr == 0) ||
                (ex == 1 && fr == 0 && sk == 0 && pr == 1) ||
                (ex == 0 && fr == 1 && sk == 1 && pr == 0) ||
                (ex == 0 && fr == 1 && sk == 0 && pr == 1) ||
                (ex == 0 && fr == 0 && sk == 1 && pr == 1))
            {
                var prof = new ProfleDtoCandidate();
                prof.ExperienceProfile = exp;
                prof.FormationProfile = form;
                prof.PreferenceProfile = pref;
                prof.SkillProfile = skill;
                var prof2 = _mapper.Map<ProfleDtoCandidate2>(prof);
                var profil3 = new ProfileDtoCandidate3();
                profil3.pourcentageProfile = 50;
                profil3.ExperienceProfile = prof2.ExperienceProfile;
                profil3.FormationProfile = prof2.FormationProfile;
                profil3.PreferenceProfile = prof2.PreferenceProfile;
                profil3.SkillProfile = prof2.SkillProfile;
                return Ok(profil3);
            }
            else if ((ex == 0 && fr == 1 && sk == 1 && pr == 1) ||
                (ex == 1 && fr == 0 && sk == 1 && pr == 1) ||
                (ex == 1 && fr == 1 && sk == 0 && pr == 1) ||
                (ex == 1 && fr == 1  && sk == 1 && pr == 0))
            {
                var prof = new ProfleDtoCandidate();
                prof.ExperienceProfile = exp;
                prof.FormationProfile = form;
                prof.PreferenceProfile = pref;
                prof.SkillProfile = skill;
                var prof2 = _mapper.Map<ProfleDtoCandidate2>(prof);
                var profil3 = new ProfileDtoCandidate3();
                profil3.pourcentageProfile = 75;
                profil3.ExperienceProfile = prof2.ExperienceProfile;
                profil3.FormationProfile = prof2.FormationProfile;
                profil3.PreferenceProfile = prof2.PreferenceProfile;
                profil3.SkillProfile = prof2.SkillProfile;
                return Ok(profil3);
            }
            else if (ex == 0 && fr == 0 && sk == 0 && pr == 0)
            {
                var prof = new ProfleDtoCandidate();
                prof.ExperienceProfile = exp;
                prof.FormationProfile = form;
                prof.PreferenceProfile = pref;
                prof.SkillProfile = skill;
                var prof2 = _mapper.Map<ProfleDtoCandidate2>(prof);
                var profil3 = new ProfileDtoCandidate3();
                profil3.pourcentageProfile = 0;
                profil3.ExperienceProfile = prof2.ExperienceProfile;
                profil3.FormationProfile = prof2.FormationProfile;
                profil3.PreferenceProfile = prof2.PreferenceProfile;
                profil3.SkillProfile = prof2.SkillProfile;
                return Ok(profil3);
            }
            else if (ex == 1 && fr == 1 && sk == 1 && pr == 1)
            {
                var prof = new ProfleDtoCandidate();
                prof.ExperienceProfile = exp;
                prof.FormationProfile = form;
                prof.PreferenceProfile = pref;
                prof.SkillProfile = skill;
                var prof2 = _mapper.Map<ProfleDtoCandidate2>(prof);
                var profil3 = new ProfileDtoCandidate3();
                profil3.pourcentageProfile = 100;
                profil3.ExperienceProfile = prof2.ExperienceProfile;
                profil3.FormationProfile = prof2.FormationProfile;
                profil3.PreferenceProfile = prof2.PreferenceProfile;
                profil3.SkillProfile = prof2.SkillProfile;
                return Ok(profil3);
            }
            throw new Exception();
        }

        [HttpGet("{ExpCode}", Name = "GetExpByCode")]
        public async Task<ActionResult<TmExpExperience>> GetExpByExpCode(int ExpCode)
        {
            var exp = await _candidateProfileRepository.GetExpByCodeExp(ExpCode);
            if (exp == null)
            {
                return NotFound(); // 404
            }

            return Ok(exp);//code 200
        }
        private async Task<TmExpExperience> CreateExperienceTable( ExperienceReadDto exp)
        {
            try
            {
                var experience = _mapper.Map<TmExpExperience>(exp);
                if (!await _candidateProfileRepository.ExpExist(experience))
                {
                    await _candidateProfileRepository.AddExperienceAsync(experience);
                    await _candidateProfileRepository.SaveChangesAsync();
                    var x = await _candidateProfileRepository.GetExpByCodeExp(experience.ExpCode);
                    return x;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }

            throw new Exception();
        }


        [HttpPost]
        [Route("CreateExperience")]
        public async Task<ActionResult<ExperienceDtoTransformed4>> CreateExperience([FromBody] ExperienceDtoCreate exp)
        {
            try
            {
                var exp1 = new ExperienceReadDto();
                exp1.ExpName = exp.ExpName;
                exp1.ExpDesc = exp.ExpDesc;
                exp1.ExpCompany = exp.ExpCompany;
                exp1.ExpInProg = exp.ExpInProg;
                exp1.ExpSdate = exp.ExpSdate;
                exp1.ExpEdate = exp.ExpEdate;
                var experience = await CreateExperienceTable(exp1);
                await _candidateProfileRepository.SaveChangesAsync();
                var ExpCode = experience.ExpCode;
                var CandidateCode = exp.CandidateCode;
                var skillCode = await _candidateProfileRepository.GetSkillCodeBySkillName(exp.SkillName!);
                var domainCode = await _candidateProfileRepository.GetDomainCodeByDomainName(exp.DomainName!);
                var countryCode = await _candidateProfileRepository.GetCountryCodeByCountryName(exp.CountryName!);
                var regionCode = await _candidateProfileRepository.GetRegionCodeByRegionName(exp.RegionName!);
                var HaveExperience = new TrHexHaveExperience();

                HaveExperience.ExpCode = ExpCode;
                HaveExperience.CandidateCode = CandidateCode;
                HaveExperience.SkillCode = skillCode;
                HaveExperience.DomainCode = domainCode;
                HaveExperience.CountryCode = countryCode;
                HaveExperience.RegionCode = regionCode;

                await _candidateProfileRepository.AddHaveExperienceAsync(HaveExperience);
                await _candidateProfileRepository.SaveChangesAsync();

                var experienceToRetun = new ExperienceDtoTransformed3();
                experienceToRetun.ExpName = experience.ExpName;
                experienceToRetun.ExpDesc = experience.ExpDesc;
                experienceToRetun.ExpCompany = experience.ExpCompany;
                experienceToRetun.ExpInProg = experience.ExpInProg;
                experienceToRetun.ExpSdate = experience.ExpSdate;
                experienceToRetun.ExpEdate = experience.ExpEdate;
                var haveExp = await _candidateProfileRepository.GetHaveExpByCodeExp(ExpCode);
                experienceToRetun.CandidateCode = haveExp.CandidateCode;
                experienceToRetun.SkillCode = haveExp.SkillCode;
                experienceToRetun.DomainCode = haveExp.DomainCode;
                experienceToRetun.CountryCode = haveExp.CountryCode;
                experienceToRetun.RegionCode = haveExp.RegionCode;
                return Ok(_mapper.Map<ExperienceDtoTransformed4>(experienceToRetun));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }

            //var ExpTransformedToReturn = GetExpTransformedByExpCode((await CreateExperienceTable(_mapper.Map<ExperienceReadDto>(exp))).ExpCode);
            //return Ok(ExpTransformedToReturn);
            throw new Exception();
        }

        private async Task<TmFrmFormation> CreateFormationTable(FormationReadDto form)
        {
            try
            {
                var formation = _mapper.Map<TmFrmFormation>(form);
                if (!await _candidateProfileRepository.FormExist(formation))
                {
                    await _candidateProfileRepository.AddFormationAsync(formation);
                    await _candidateProfileRepository.SaveChangesAsync();
                    var f = await _candidateProfileRepository.GetFormByCodeForm(formation.FormCode);
                    return f;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }

            throw new Exception();
        }

        [HttpPost]
        [Route("CreateFormation")]
        public async Task<ActionResult<FormationDtoTransformed3>> CreateFormation([FromBody] FormationDtoCreate form)
        {
            try
            {
                var form1 = new FormationReadDto();
                form1.FormName = form.FormName;
                form1.FormGrad = form.FormGrad;
                form1.FormDesc = form.FormDesc;
                form1.SchoolName = form.SchoolName;
                form1.FormInProg = form.FormInProg;
                form1.FormSdate = form.FormSdate;
                form1.FormEdate = form.FormEdate;
                
                var formation = await CreateFormationTable(form1);
                await _candidateProfileRepository.SaveChangesAsync();

                var FormCode = formation.FormCode;
                var CandidateCode = form.CandidateCode;
                var countryCode = await _candidateProfileRepository.GetCountryCodeByCountryName(form.CountryName!);
                var regionCode = await _candidateProfileRepository.GetRegionCodeByRegionName(form.RegionName!);
                var HaveFormation = new TrHfrHaveFormation();

                HaveFormation.FormCode = FormCode;
                HaveFormation.CandidateCode = CandidateCode;
                HaveFormation.RegionCode = regionCode;
                HaveFormation.CountryCode = countryCode;



                await _candidateProfileRepository.AddHaveFormationAsync(HaveFormation);
                await _candidateProfileRepository.SaveChangesAsync();

                var FormationToReturn = new FormationDtoTransformed3();
                FormationToReturn.FormGrad = formation.FormGrad;
                FormationToReturn.FormName = formation.FormName;
                FormationToReturn.FormDesc = formation.FormDesc;
                FormationToReturn.SchoolName = formation.SchoolName;
                FormationToReturn.FormInProg = formation.FormInProg;
                FormationToReturn.FormSdate = formation.FormSdate;
                FormationToReturn.FormEdate = formation.FormEdate;
                var haveForm = await _candidateProfileRepository.GetHaveFormByCodeForm(FormCode);
                FormationToReturn.CandidateCode = haveForm.CandidateCode;
                FormationToReturn.CountryCode = haveForm.CountryCode;
                FormationToReturn.RegionCode = haveForm.RegionCode;

                return Ok(FormationToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }
            throw new Exception();
        }

        private async Task<TmSklSkill> CreateSkillTable(SkillReadDto sk)
        {
            try
            {
                var skill = _mapper.Map<TmSklSkill>(sk);
                if (!await _candidateProfileRepository.SkillExist(skill))
                {
                    await _candidateProfileRepository.AddSkillAsync(skill);
                    await _candidateProfileRepository.SaveChangesAsync();
                    var s = await _candidateProfileRepository.GetSkillBySkillCode(skill.SkillCode);
                    return s;
                }
                else
                {
                    var s = await _candidateProfileRepository.GetSkillBySkillName(sk.SkillName);
                    return s;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }

            throw new Exception();
        }

        [HttpPost]
        [Route("CreateSkill")]
        public async Task<ActionResult<SkillDtoCreate>> CreateSkill([FromBody] SkillDtoCreate sk)
        {
            try
            {
                var sk1 = new SkillReadDto();
                sk1.SkillName = sk.SkillName;
                sk1.SkillDesc = sk.SkillDesc;

                var skill = await CreateSkillTable(sk1);
                await _candidateProfileRepository.SaveChangesAsync();

                var SkillCode = skill.SkillCode;
                var CandidateCode = sk.CandidateCode;
                var SkillLevel = sk.SkillLevel;
                var HaveSkill = new TrCskCandidateSkill();

                HaveSkill.SkillCode = SkillCode;
                HaveSkill.CandidateCode = CandidateCode;
                HaveSkill.SkillLevel = SkillLevel;

                await _candidateProfileRepository.AddHaveSkillAsync(HaveSkill);
                await _candidateProfileRepository.SaveChangesAsync();

                var skillToReturn = new SkillDtoCreate();
                skillToReturn.SkillName = skill.SkillName;
                skillToReturn.SkillDesc = skill.SkillDesc;
                skillToReturn.CandidateCode = CandidateCode;
                skillToReturn.SkillLevel = SkillLevel;

                return Ok(skillToReturn);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }
            throw new Exception();
        }

        private async Task<TmPrfPreference> CreatePreferenceTable(PreferenceReadDto pref)
        {
            try
            {
                var preference = _mapper.Map<TmPrfPreference>(pref);
                if (!await _candidateProfileRepository.PrefExist(preference))
                {
                    await _candidateProfileRepository.AddPrefAsync(preference);
                    await _candidateProfileRepository.SaveChangesAsync();
                    var pr = await _candidateProfileRepository.GetPrefByPrefCode(preference.PrefCode);
                    return pr;
                }
                else
                {
                    var p = await _candidateProfileRepository.GetPrefByAllProp(pref.DesiredSalary, pref.PrefMobility, (int)pref.CtrCode!);
                    return p;
                }
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption {ex.Message}");
            }

            throw new Exception();
        }


        [HttpPost]
        [Route("CreatePreference")]
        public async Task<ActionResult<PreferenceDtoTransformed3>> CreatePreference([FromBody] PreferenceDtoCreate pr)
        {
            try
            {
                //preferenceExisteOrNotForThisCandidate:
                var p = await _candidateProfileRepository.verifyExistenceOfPreferenceForCandidate(pr.CandidateCode);
                if (p)
                {
                    await _candidateProfileRepository.DeletePrefIFExist(pr.CandidateCode);
                }

                var pr1 = new PreferenceReadDto();
                pr1.DesiredSalary = pr.DesiredSalary;
                pr1.PrefMobility = pr.PrefMobility;
                pr1.CtrCode = await _candidateProfileRepository.GetCtrCodeByCtrName(pr.CtrName!);
               
                var preference = await CreatePreferenceTable(pr1);
                await _candidateProfileRepository.SaveChangesAsync();

                var PrefCode = preference.PrefCode;
                var CandidateCode = pr.CandidateCode;
                var DomainCode = await _candidateProfileRepository.GetDomainCodeByDomainName(pr.DomainName!);

                var havePref = new TrHprHavePreference();
                havePref.PrefCode =  PrefCode;
                havePref.CandidateCode = CandidateCode;
                havePref.DomainCode = DomainCode;

                await _candidateProfileRepository.AddHavePrefAsync(havePref);
                await _candidateProfileRepository.SaveChangesAsync();
                var prefToReturn = new PreferenceDtoTransformed3();
                prefToReturn.DesiredSalary = preference.DesiredSalary;
                prefToReturn.PrefMobility = preference.PrefMobility;
                prefToReturn.CtrCode = preference.CtrCode;
                var havePrefToReturn = await _candidateProfileRepository.GetHavePrefByCodePref(PrefCode);
                prefToReturn.CandidateCode = havePrefToReturn.CandidateCode;
                prefToReturn.DomainCode = havePrefToReturn.DomainCode;
                return Ok(prefToReturn);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption ***************** {ex.Message}");
                Console.WriteLine($"Exception occurred /////////////////////////////////// : {ex.Message}");
            }
            throw new Exception();
        }

        [HttpGet()]
        [Route("GetAllSkills")]
        public async Task<ActionResult<IEnumerable<TmSklSkill>>> GetAllSkills()
        {
            var skills = await _candidateProfileRepository.GetAllSkillsAsync();
            return Ok(skills);
        }
        [HttpGet()]
        [Route("GetAllDomains")]
        public async Task<ActionResult<IEnumerable<TmDmnDomain>>> GetAllDomains()
        {
            var domains = await _candidateProfileRepository.GetAllDomainsAsync();
            return Ok(domains);
        }

        [HttpGet()]
        [Route("GetAllCountries")]
        public async Task<ActionResult<IEnumerable<TmCotCountry>>> GetAllCountries()
        {
            var countries = await _candidateProfileRepository.GetAllCountryAsync();
            return Ok(countries);
        }

        [HttpGet()]
        [Route("GetAllRegions")]
        public async Task<ActionResult<IEnumerable<TmRegRegion>>> GetAllRegions(string countryName)
        {
            var regions = await _candidateProfileRepository.GetAllRegionAsync(countryName);
            return Ok(regions);
        }



        [HttpPost]
        [Route("Apply")]
        public async Task<ActionResult<ApplyDtoCreate>> Apply([FromBody] ApplyDtoCreate app)
        {
            try
            {
                var app1 = _mapper.Map<TrAppApply>(app);
                if (await _candidateProfileRepository.ApplyExist(app1))
                {
                    //throw new Exception($"you have already applied for this job");
                    return BadRequest(new { error = "you have already applied for this job" });
                }

                await _candidateProfileRepository.AddApplyAsync(app1);
                await _candidateProfileRepository.SaveChangesAsync();

                var app2 = await _candidateProfileRepository.getApplyAsync(app1);
                return Ok(_mapper.Map<ApplyDtoCreate>(app2));
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"Exeption ***************** {ex.Message}");
                Console.WriteLine($"Exception occurred /////////////////////////////////// : {ex.Message}");
            }
            throw new Exception();
        }


        [HttpGet()]
        [Route("MyJobsApply")]
        public async Task<ActionResult<IEnumerable<MyJobApplication>>> GetMyApplications(string Email)
        {
            var jobs = await _candidateProfileRepository.GetMyJobApplicationByCandidateAdress(Email);
            if (jobs == null)
            {
                return NotFound(); // 404
            }

            return Ok(jobs);//code 200
        }


    }
}
