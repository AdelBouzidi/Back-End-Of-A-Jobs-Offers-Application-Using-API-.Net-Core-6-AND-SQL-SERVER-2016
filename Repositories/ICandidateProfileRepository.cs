using Job_Offre.Entities;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;
using Job_Offre.Models.Dtos.JobCandidateDtos;
using Job_Offre.Models.Dtos.JobDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;
using Job_Offre.Models.Dtos.SkillDtos;

namespace Job_Offre.Repositories
{
    public interface ICandidateProfileRepository
    {
        Task<IEnumerable<ExperienceDtoTransformed>> GetCandidateExp(string mail);
        Task<IEnumerable<FormationDtoTransformed>> GetCandidateForm(string mail);
        Task<IEnumerable<SkillDtoTransformed>> GetCandidateSkill(string mail);
        Task<PreferenceDtoTransformed> GetCandidatePref(string mail);
        //Task AddExperienceAsync(ExperienceReadDto exp);
        Task AddExperienceAsync(TmExpExperience exp);
        Task<TmExpExperience> GetExpByCodeExp(int expCode);
        Task<int> GetSkillCodeBySkillName(string skillName);
        Task<int> GetDomainCodeByDomainName(string domainName);
        Task<int> GetCountryCodeByCountryName(string countryName);
        Task<int> GetRegionCodeByRegionName(string regionName);
        Task AddHaveExperienceAsync(TrHexHaveExperience haveExp);
        Task<TrHexHaveExperience> GetHaveExpByCodeExp(int expCode);
        Task<bool> ExpExist(TmExpExperience exp);
        Task AddFormationAsync(TmFrmFormation form);
        Task<bool> FormExist(TmFrmFormation form);
        Task<TmFrmFormation> GetFormByCodeForm(int formCode);
        Task AddHaveFormationAsync(TrHfrHaveFormation haveForm);
        Task<bool> SkillExist(TmSklSkill skill);
        Task AddSkillAsync(TmSklSkill skill);
        Task AddHaveSkillAsync(TrCskCandidateSkill haveSkill);
        Task<TmSklSkill> GetSkillBySkillCode(int skillCode);
        Task<TmPrfPreference> GetPrefByPrefCode(int prefCode);
        Task<bool> PrefExist(TmPrfPreference pref);
        Task<int> GetCtrCodeByCtrName(string ctrName);
        Task AddPrefAsync(TmPrfPreference pref);
        Task AddHavePrefAsync(TrHprHavePreference havePref);
        Task<bool> verifyExistenceOfPreferenceForCandidate(int candidateCode);
        Task<TmSklSkill> GetSkillBySkillName(string skillName);
        Task<IEnumerable<TmSklSkill>> GetAllSkillsAsync();
        Task<IEnumerable<TmDmnDomain>> GetAllDomainsAsync();
        Task<IEnumerable<TmCotCountry>> GetAllCountryAsync();
        Task<IEnumerable<TmRegRegion>> GetAllRegionAsync(string countryName);
        Task<TrHfrHaveFormation> GetHaveFormByCodeForm(int formCode);
        Task<TmPrfPreference> GetPrefByAllProp(float DesiredSalary, string PrefMobility, int CtrCode);
        Task<TrHprHavePreference> GetHavePrefByCodePref(int prefCode);
        Task DeletePrefIFExist(int cndCode);
        Task AddApplyAsync(TrAppApply app);
        Task<bool> ApplyExist(TrAppApply app);
        Task<TrAppApply> getApplyAsync(TrAppApply app);
        Task<IEnumerable<JobCandidatesReadDto>> getJobsAndCandidatesApplyByRecCode(int recruiterCode);
        Task<IEnumerable<MyJobApplication>> GetMyJobApplicationByCandidateAdress(string mail);
        Task<bool> SaveChangesAsync();
    }
}