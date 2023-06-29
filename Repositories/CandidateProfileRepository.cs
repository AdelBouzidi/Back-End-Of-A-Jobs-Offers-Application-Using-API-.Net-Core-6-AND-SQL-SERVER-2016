using Job_Offre.Entities;
using Job_Offre.Models;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;
using Job_Offre.Models.Dtos.JobCandidateDtos;
using Job_Offre.Models.Dtos.JobDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;
using Job_Offre.Models.Dtos.ProfileDto;
using Job_Offre.Models.Dtos.SkillDtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection.Emit;

namespace Job_Offre.Repositories
{
    public class CandidateProfileRepository : ICandidateProfileRepository
    {
        private readonly offres_JobContext _context;
        public CandidateProfileRepository(offres_JobContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<ExperienceDtoTransformed>> GetCandidateExp(string mail)
        {
            var exp = from cnd in _context.TmCndCandidates
                      join hex in _context.TrHexHaveExperiences on cnd.CandidateCode equals hex.CandidateCode
                      join ex in _context.TmExpExperiences on hex.ExpCode equals ex.ExpCode
                      join ct in _context.TmCotCountries on hex.CountryCode equals ct.CountryCode
                      join rj in _context.TmRegRegions on hex.RegionCode equals rj.RegionCode
                      join dm in _context.TmDmnDomains on hex.DomainCode equals dm.DomainCode
                      join sk in _context.TmSklSkills on hex.SkillCode equals sk.SkillCode
                      where cnd.CandidateAdress == mail
                      select new ExperienceDtoTransformed
                      {
                          ExpName = ex.ExpName,
                          ExpDesc = ex.ExpDesc,
                          ExpCompany = ex.ExpCompany,
                          ExpInProg = ex.ExpInProg,
                          ExpSdate = ex.ExpSdate,
                          ExpEdate = ex.ExpEdate,
                          SkillName = sk.SkillName,
                          DomainName = dm.DomainName,
                          CountryName = ct.CountryName,
                          RegionName = rj.RegionName,
                      };
            var experience = exp.ToList();
            return experience;
        }

        public async Task<IEnumerable<FormationDtoTransformed>> GetCandidateForm(string mail)
        {
            var form1 = from cnd in _context.TmCndCandidates
                        join hf in _context.TrHfrHaveFormations on cnd.CandidateCode equals hf.CandidateCode
                        join f in _context.TmFrmFormations on hf.FormCode equals f.FormCode
                        join ct in _context.TmCotCountries on hf.CountryCode equals ct.CountryCode
                        join rj in _context.TmRegRegions on hf.RegionCode equals rj.RegionCode
                        where cnd.CandidateAdress == mail
                        select new FormationDtoTransformed
                        {
                            FormCode = f.FormCode,
                            FormGrad = f.FormGrad,
                            FormName = f.FormName,
                            FormDesc = f.FormDesc,
                            SchoolName = f.SchoolName,
                            FormInProg = f.FormInProg,
                            FormSdate = f.FormSdate,
                            FormEdate = f.FormEdate,
                            CountryName = ct.CountryName,
                            RegionName = rj.RegionName,
                        };

            var formation = form1.ToList();
            return formation;
        }


        public async Task<IEnumerable<SkillDtoTransformed>> GetCandidateSkill(string mail)
        {
            var skill = from cnd in _context.TmCndCandidates
                        join hv_sk in _context.TrCskCandidateSkills on cnd.CandidateCode equals hv_sk.CandidateCode
                        join sk in _context.TmSklSkills on hv_sk.SkillCode equals sk.SkillCode
                        where cnd.CandidateAdress == mail
                        select new SkillDtoTransformed
                        {
                            SkillCode = sk.SkillCode,
                            SkillName = sk.SkillName,
                            SkillDesc = sk.SkillDesc,
                            SkillLevel = hv_sk.SkillLevel,
                        };

            var skill1 = skill.ToList();
            return skill1;
        }

        public async Task<PreferenceDtoTransformed> GetCandidatePref(string mail)
        {
            var pref = from cnd in _context.TmCndCandidates
                       join hp in _context.TrHprHavePreferences on cnd.CandidateCode equals hp.CandidateCode
                       join p in _context.TmPrfPreferences on hp.PrefCode equals p.PrefCode
                       join dm in _context.TmDmnDomains on hp.DomainCode equals dm.DomainCode
                       join tc in _context.TcCtrTypeContracts on p.CtrCode equals tc.CtrCode
                       where cnd.CandidateAdress == mail
                       select new PreferenceDtoTransformed
                       {
                           PrefCode = p.PrefCode,
                           DesiredSalary = p.DesiredSalary,
                           PrefMobility = p.PrefMobility,
                           CtrName = tc.CtrLabel,
                           DomainName = dm.DomainName,
                       };

            return await pref.FirstOrDefaultAsync();
        }


        public async Task AddExperienceAsync(TmExpExperience exp)
        {
            //var experience = new TmExpExperience
            //{
            //    ExpName = exp.ExpName,
            //    ExpDesc = exp.ExpDesc,
            //    ExpCompany = exp.ExpCompany,
            //    ExpInProg = exp.ExpInProg,
            //    ExpSdate = exp.ExpSdate,
            //    ExpEdate = exp.ExpEdate,
            //};
            await _context.TmExpExperiences.AddAsync(exp);
        }
        public async Task AddFormationAsync(TmFrmFormation form)
        {
            await _context.TmFrmFormations.AddAsync(form);
        }
        public async Task<bool> FormExist(TmFrmFormation form)
        {
            return await _context.TmFrmFormations.AnyAsync(f => f.FormName == form.FormName &&
            f.FormGrad == form.FormGrad && f.FormDesc == form.FormDesc && f.SchoolName == form.SchoolName
            && f.FormInProg == form.FormInProg && f.FormSdate == form.FormSdate && f.FormEdate == form.FormEdate);
        }
        public async Task<bool> SkillExist(TmSklSkill skill)
        {
            return await _context.TmSklSkills.AnyAsync(s => s.SkillName == skill.SkillName);
        }
        public async Task<TmSklSkill> GetSkillBySkillName(string skillName)
        {
            return await _context.TmSklSkills.FirstAsync(s => s.SkillName == skillName);
        }
        public async Task AddSkillAsync(TmSklSkill skill)
        {
            await _context.TmSklSkills.AddAsync(skill);
        }
        public async Task AddHaveSkillAsync(TrCskCandidateSkill haveSkill)
        {
            await _context.TrCskCandidateSkills.AddAsync(haveSkill);
        }
        public async Task<TmSklSkill> GetSkillBySkillCode( int skillCode)
        {
            return await _context.TmSklSkills.FirstAsync(s => s.SkillCode == skillCode);
        }
        public async Task AddPrefAsync(TmPrfPreference pref)
        {
            await _context.TmPrfPreferences.AddAsync(pref);
        }
        public async Task AddHavePrefAsync(TrHprHavePreference havePref)
        {
            await _context.TrHprHavePreferences.AddAsync(havePref);
        }

        public async Task<bool> verifyExistenceOfPreferenceForCandidate(int candidateCode)
        {
            return await _context.TrHprHavePreferences.AnyAsync(hp => hp.CandidateCode == candidateCode);
        }

        public async Task<int> GetCtrCodeByCtrName(string ctrName)
        {
            var contract = await _context.TcCtrTypeContracts.FirstAsync(c => c.CtrLabel == ctrName);
            return contract.CtrCode;
        }
        public async Task<bool> PrefExist(TmPrfPreference pref)
        {
            return await _context.TmPrfPreferences.AnyAsync(p => p.DesiredSalary == pref.DesiredSalary
            && p.PrefMobility == pref.PrefMobility && p.CtrCode == pref.CtrCode);
        }
        public async Task<TmPrfPreference> GetPrefByAllProp(float DesiredSalary, string PrefMobility, int CtrCode)
        {
            return await _context.TmPrfPreferences.Where(p => p.DesiredSalary == DesiredSalary
            && p.PrefMobility == PrefMobility && p.CtrCode == CtrCode).FirstAsync();
        }

        public async Task DeletePrefIFExist(int cndCode)
        {
            var pref = from p in _context.TmPrfPreferences
                       join hp in _context.TrHprHavePreferences
                       on p.PrefCode equals hp.PrefCode
                       where hp.CandidateCode == cndCode
                       select new TmPrfPreference
                       {
                           PrefCode = p.PrefCode,
                           DesiredSalary = p.DesiredSalary,
                           PrefMobility = p.PrefMobility,
                           CtrCode = p.CtrCode
                       };
            var havePref = from p in _context.TmPrfPreferences
                       join hp in _context.TrHprHavePreferences
                       on p.PrefCode equals hp.PrefCode
                       where hp.CandidateCode == cndCode
                       select new TrHprHavePreference
                       {
                           CandidateCode = hp.CandidateCode,
                           PrefCode = hp.PrefCode,
                           DomainCode = hp.DomainCode
                       };
            _context.TrHprHavePreferences.RemoveRange(havePref);
            _context.TmPrfPreferences.RemoveRange(pref);
        }
        public async Task<TmPrfPreference> GetPrefByPrefCode(int prefCode)
        {
            return await _context.TmPrfPreferences.FirstAsync(p => p.PrefCode == prefCode);
        }
        public async Task<bool> ExpExist(TmExpExperience exp)
        {
            return await _context.TmExpExperiences.AnyAsync(ex => ex.ExpName == exp.ExpName && ex.ExpDesc == exp.ExpDesc
            && ex.ExpCompany == exp.ExpCompany && ex.ExpInProg == exp.ExpInProg && ex.ExpSdate == exp.ExpSdate 
            && ex.ExpEdate == exp.ExpEdate);
        }
        public async Task<TmExpExperience> GetExpByCodeExp( int expCode)
        {
            return await _context.TmExpExperiences.FirstAsync(e => e.ExpCode == expCode);
        }
        public async Task<TmFrmFormation> GetFormByCodeForm(int formCode)
        {
            return await _context.TmFrmFormations.FirstAsync(f => f.FormCode == formCode);
        }
        public async Task<TrHfrHaveFormation> GetHaveFormByCodeForm(int formCode)
        {
            return await _context.TrHfrHaveFormations.FirstAsync(f => f.FormCode == formCode);
        }
        public async Task<TrHexHaveExperience> GetHaveExpByCodeExp(int expCode)
        {
            return await _context.TrHexHaveExperiences.FirstAsync(he => he.ExpCode == expCode);
        }
        public async Task<TrHprHavePreference> GetHavePrefByCodePref(int prefCode)
        {
            return await _context.TrHprHavePreferences.FirstAsync(p => p.PrefCode == prefCode);
        }
        public async Task<int> GetSkillCodeBySkillName( string skillName)
        {
            var skill= await _context.TmSklSkills.FirstAsync(s => s.SkillName == skillName);
            return skill.SkillCode;
        }
        public async Task<int> GetDomainCodeByDomainName(string domainName)
        {
            var domain = await _context.TmDmnDomains.FirstAsync(d => d.DomainName == domainName);
            return domain.DomainCode;
        }
        public async Task<int> GetCountryCodeByCountryName(string countryName)
        {
            var country = await _context.TmCotCountries.FirstAsync(c => c.CountryName == countryName);
            return country.CountryCode;
        }
        public async Task<int> GetRegionCodeByRegionName(string regionName)
        {
            var region = await _context.TmRegRegions.FirstAsync(r => r.RegionName == regionName);
            return region.RegionCode;
        }
        public async Task AddHaveExperienceAsync(TrHexHaveExperience haveExp)
        {
            await _context.TrHexHaveExperiences.AddAsync(haveExp);
        }
        public async Task AddHaveFormationAsync(TrHfrHaveFormation haveForm)
        {
            await _context.TrHfrHaveFormations.AddAsync(haveForm);
        }
        public async Task<IEnumerable<TmSklSkill>> GetAllSkillsAsync()
        {
            var s = await _context.TmSklSkills.OrderByDescending(s => s.SkillCode).ToListAsync();
            return s;
        }
        public async Task<IEnumerable<TmDmnDomain>> GetAllDomainsAsync()
        {
            var d = await _context.TmDmnDomains.OrderByDescending(d => d.DomainCode).ToListAsync();
            return d;
        }
        public async Task<IEnumerable<TmCotCountry>> GetAllCountryAsync()
        {
            var c = await _context.TmCotCountries.OrderByDescending(c => c.CountryCode).ToListAsync();
            return c;
        }
        public async Task<IEnumerable<TmRegRegion>> GetAllRegionAsync( string countryName)
        {
            var regions = from r in _context.TmRegRegions
                          join c in _context.TmCotCountries on r.CountryCode equals c.CountryCode
                          where c.CountryName == countryName
                          select new TmRegRegion
                          {
                              RegionCode = r.RegionCode,
                              RegionName = r.RegionName,
                              CountryCode = r.CountryCode
                          };
            return await regions.ToListAsync();
        }


        public async Task AddApplyAsync(TrAppApply app)
        {
            await _context.TrAppApplies.AddAsync(app);
        }
        public async Task<bool> ApplyExist(TrAppApply app)
        {
            return await _context.TrAppApplies.AnyAsync(a => a.CandidateCode == app.CandidateCode
            && a.JobCode == app.JobCode && a.ApplyDate == app.ApplyDate);
        }
        public async Task<TrAppApply> getApplyAsync(TrAppApply app)
        {
            return await _context.TrAppApplies.Where(a => a.CandidateCode == app.CandidateCode
            && a.JobCode == app.JobCode && a.ApplyDate == app.ApplyDate).FirstAsync();
        }
        public async Task<IEnumerable<MyJobApplication>> GetMyJobApplicationByCandidateAdress(string mail)
        {
            var jobs = from cnd in _context.TmCndCandidates
                       join app in _context.TrAppApplies
                       on cnd.CandidateCode equals app.CandidateCode
                       join job in _context.TmJobJobs
                       on app.JobCode equals job.JobCode
                       join dmn in _context.TmDmnDomains
                       on job.DomainCode equals dmn.DomainCode
                       join reg in _context.TmRegRegions
                       on job.RegionCode equals reg.RegionCode
                       join ctr in _context.TcCtrTypeContracts
                       on job.CtrCode equals ctr.CtrCode
                       join rec in _context.TmRecRecruiters
                       on job.RecruiterCode equals rec.RecruiterCode
                       where cnd.CandidateAdress == mail
                       select new MyJobApplication
                       {
                           JobCode = job.JobCode,
                           JobName = job.JobName,
                           JobDesc = job.JobDesc,
                           JobLevel = job.JobLevel,
                           JobExpDate = job.JobExpDate,
                           JobMode = job.JobMode,
                           DomainName = dmn.DomainName,
                           RegionName = reg.RegionName,
                           RecruiterAdress = rec.RecruiterAdress,
                           RecruiterFName = rec.RecruiterFname,
                           RecruiterLName = rec.RecruiterLname,
                           CtrName = ctr.CtrLabel,
                           NumberOfPosts = job.NumberOfPosts,
                           YearExperienceRequired = job.YearExperienceRequired,
                           FrenchLevel = job.FrenchLevel,
                           EnglishLevel = job.EnglishLevel,
                           Graduate = job.Graduate,
                           ApplyDate = app.ApplyDate
                       };
            return await jobs.ToListAsync();
        }

        public async Task<IEnumerable<JobCandidatesReadDto>> getJobsAndCandidatesApplyByRecCode(int recruiterCode)
        {
            var jc = from rec in _context.TmRecRecruiters
                     join job in _context.TmJobJobs
                     on rec.RecruiterCode equals job.RecruiterCode
                     join app in _context.TrAppApplies
                     on job.JobCode equals app.JobCode
                     join cnd in _context.TmCndCandidates
                     on app.CandidateCode equals cnd.CandidateCode
                     join dmn in _context.TmDmnDomains
                     on job.DomainCode equals dmn.DomainCode
                     join reg in _context.TmRegRegions 
                     on job.RegionCode equals reg.RegionCode
                     join ctr in _context.TcCtrTypeContracts
                     on job.CtrCode equals ctr.CtrCode
                     where rec.RecruiterCode == recruiterCode
                     select new JobCandidatesReadDto
                     {
                         Job = new JobDtoCreateTransformed3
                         {
                             JobCode = job.JobCode,
                             JobName = job.JobName,
                             JobDesc = job.JobDesc,
                             JobLevel = job.JobLevel,
                             JobExpDate = job.JobExpDate,
                             JobMode = job.JobMode,
                             DomainName = dmn.DomainName,
                             RegionName = reg.RegionName,
                             RecruiterCode = job.RecruiterCode,
                             CtrName = ctr.CtrLabel,
                             NumberOfPosts = job.NumberOfPosts,
                             YearExperienceRequired = job.YearExperienceRequired,
                             FrenchLevel = job.FrenchLevel,
                             EnglishLevel = job.EnglishLevel,
                             Graduate = job.Graduate
                         },
                         Candidates = new List<CandidateDto>
                     {
                         new CandidateDto
                         {
                             CandidateCode = cnd.CandidateCode,
                             CandidateFname = cnd.CandidateFname,
                             CandidateLname = cnd.CandidateLname,
                             CandidateAdress = cnd.CandidateAdress,
                             CandidatePhone = cnd.CandidatePhone,
                             CandidateMs = cnd.CandidateMs,
                             CandidateDesc = cnd.CandidateDesc,
                             GenderCode = cnd.GenderCode,
                             UserCode = cnd.UserCode
                         }
                     }
                     };
            //JobCandidatesReadDto result = jc.ToList();

            return jc.ToList();
        }

        public async Task<bool> SaveChangesAsync()
        {
            //return (await _context.SaveChangesAsync() >= 0);
            try
            {
                return await _context.SaveChangesAsync() >= 0;
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(" ******************* Inner Exception ******************* ");
                    Console.WriteLine(string.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
                return false;
            }
        }
    }
}
