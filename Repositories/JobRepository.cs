using Job_Offre.Entities;
using Job_Offre.Models;
using Job_Offre.Models.Dtos.JobDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
//using System.Data.Entity;
//using System.Data.Entity;
using System.Net.Mail;
using System.Reflection.Emit;

namespace Job_Offre.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly offres_JobContext _context;

        public JobRepository(offres_JobContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<IEnumerable<TmJobJob>> GetJobsAsync()
        {
            var jobs = await _context.TmJobJobs.OrderBy(c => c.JobCode).ToListAsync();
            return jobs;
        }
        public async Task<TmJobJob> GetJobsByJobCodeAsync(int JCode)
        {
            return await _context.TmJobJobs.FirstAsync(c => c.JobCode == JCode);
        }
        public async Task<IEnumerable<TmCndCandidate>> GetCandidatesAsync()
        {
            return await _context.TmCndCandidates.OrderBy(c => c.CandidateCode).ToListAsync();
        }


        // hadi manich nutilisiha dert fi plasetha GetRecruiterByEmail et candidateByEmail, mais
        // lghalta li dertha c que rani n9sod b hadou GetRecruiterByEmail et candidateByEmail : get user by emails.
        //public async Task<TmUsrUserAccount> GetUserByEmail(string mail, string role) 
        //{
        //    var user = from cnd in _context.TmCndCandidates
        //               join usr in _context.TmUsrUserAccounts
        //               on cnd.UserCode equals usr.UserCode
        //               where (cnd.CandidateAdress == mail)
        //               select new TmUsrUserAccount
        //               {
        //                   UserCode = usr.UserCode,
        //                   UserName = usr.UserName,
        //                   UserPw = usr.UserPw,
        //                   RoleCode = usr.RoleCode,
        //               };
        //    var utilisateur = from rec in _context.TmRecRecruiters
        //                      join usr in _context.TmUsrUserAccounts
        //                      on rec.UserCode equals usr.UserCode
        //                      where (rec.RecruiterAdress == mail)
        //                      select new TmUsrUserAccount
        //                      {
        //                          UserCode = usr.UserCode,
        //                          UserName = usr.UserName,
        //                          UserPw = usr.UserPw,
        //                          RoleCode = usr.RoleCode,
        //                      };
        //    if (role == "candidate")
        //    {
        //        return await user.FirstAsync();
        //    }
        //    if (role == "recruiter")
        //    {
        //        return await utilisateur.FirstAsync();
        //    }
        //    throw new Exception("Please indicate the role correctly (recruiter/candidate)");
        //}
        //public async Task<TmUsrUserAccount> GetUserByCode(int code)
        //{
        //    return await _context.TmUsrUserAccounts.Where(u => u.UserCode == code).FirstOrDefaultAsync();
        //}


        //public async Task<TmUsrUserAccount> GetRecruiterByEmail(string mail)
        //{
        //    var utilisateur = from rec in _context.TmRecRecruiters
        //                      join usr in _context.TmUsrUserAccounts
        //                      on rec.UserCode equals usr.UserCode
        //                      where (rec.RecruiterAdress == mail)
        //                      select new TmUsrUserAccount
        //                      {
        //                          UserCode = usr.UserCode,
        //                          UserName = usr.UserName,
        //                          UserPw = usr.UserPw,
        //                          RoleCode = usr.RoleCode,
        //                      };
        //    return await utilisateur.FirstAsync();
        //}
        //public async Task<TmUsrUserAccount> GetCandidateByEmail(string mail)
        //{
        //    var user = from cnd in _context.TmCndCandidates
        //               join usr in _context.TmUsrUserAccounts
        //               on cnd.UserCode equals usr.UserCode
        //               where (cnd.CandidateAdress == mail)
        //               select new TmUsrUserAccount
        //               {
        //                   UserCode = usr.UserCode,
        //                   UserName = usr.UserName,
        //                   UserPw = usr.UserPw,
        //                   RoleCode = usr.RoleCode,
        //               };
        //    return await user.FirstAsync();
        //}
        public async Task AddJobAsync(TmJobJob job)
        {

            await _context.TmJobJobs.AddAsync(job);
            //var res = await _context.SaveChangesAsync();
        }
        //public async Task<TmUsrUserAccount> GetUserAsync()
        //{
        //    var user = await _context.TmUsrUserAccounts.OrderByDescending(c => c.UserCode).FirstAsync();
        //    return user;
        //}
        //public async Task<TmUsrUserAccount> AddUserAsync(TmUsrUserAccount user)
        //{
        //    try
        //    {
        //        await _context.TmUsrUserAccounts.AddAsync(user);
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.WriteLine($"Exeptions AddUserAsync {ex.Message}");
        //    }
        //    var userAdded = await GetUserAsync();
        //    return userAdded;
        //}
        //public async Task<bool> RecruiterExistAsync(string mail)
        //{
        //    return await _context.TmRecRecruiters.AnyAsync(c => c.RecruiterAdress == mail);
        //}
        //public async Task AddRecruiterAsync(TmRecRecruiter recruiter)
        //{
        //    await _context.TmRecRecruiters.AddAsync(recruiter);
        //}
        //public async Task<TmRecRecruiter> GetRecruiterByAdressMail(string mail)
        //{
        //    return await _context.TmRecRecruiters.Where(r => r.RecruiterAdress == mail).FirstOrDefaultAsync();
        //}

        public async Task<IEnumerable<JobDtoTransformed>> GetJobsTransformedAsync()
        {
            var job = from jb in _context.TmJobJobs
                      join dm in _context.TmDmnDomains
                      on jb.DomainCode equals dm.DomainCode
                      join rj in _context.TmRegRegions
                      on jb.RegionCode equals rj.RegionCode
                      join rec in _context.TmRecRecruiters
                      on jb.RecruiterCode equals rec.RecruiterCode
                      join ct in _context.TcCtrTypeContracts
                      on jb.CtrCode equals ct.CtrCode
                      select new JobDtoTransformed
                      {
                          JobCode = jb.JobCode,
                          JobName = jb.JobName,
                          JobDesc = jb.JobDesc,
                          JobLevel = jb.JobLevel,
                          JobExpDate = jb.JobExpDate,
                          JobMode = jb.JobMode,
                          DomainName = dm.DomainName,
                          RegionName = rj.RegionName,
                          RecruiterFName = rec.RecruiterFname,
                          RecruiterLName = rec.RecruiterLname,
                          RecruiterMail = rec.RecruiterAdress,
                          CtrName = ct.CtrLabel,
                          NumberOfPosts = jb.NumberOfPosts,
                          YearExperienceRequired = jb.YearExperienceRequired,
                          FrenchLevel = jb.FrenchLevel,
                          EnglishLevel = jb.EnglishLevel,
                          Graduate = jb.Graduate
                      };
            var jobs = job.ToList();
            return jobs;
        }
        public async Task<bool> JobExist(JobDtoCreate job)
        {
            return await _context.TmJobJobs.AnyAsync(j => j.JobName == job.JobName &&
            j.JobDesc == job.JobDesc && j.JobLevel == job.JobLevel && j.JobExpDate == job.JobExpDate &&
            j.JobMode == job.JobMode && j.DomainCode == job.DomainCode && j.RegionCode == job.RegionCode
            && j.RecruiterCode == job.RecruiterCode && j.CtrCode == job.CtrCode && j.NumberOfPosts == job.NumberOfPosts
            && j.YearExperienceRequired == job.YearExperienceRequired && j.FrenchLevel == job.FrenchLevel 
            && job.EnglishLevel == job.EnglishLevel && j.Graduate == job.Graduate);
        }
        public async Task<TmJobJob> GetJobByALLprop(JobDtoCreate job)
        {
            return await _context.TmJobJobs.Where(j => j.JobName == job.JobName &&
            j.JobDesc == job.JobDesc && j.JobLevel == job.JobLevel && j.JobExpDate == job.JobExpDate &&
            j.JobMode == job.JobMode && j.DomainCode == job.DomainCode && j.RegionCode == job.RegionCode
            && j.RecruiterCode == job.RecruiterCode && j.CtrCode == job.CtrCode && j.NumberOfPosts == job.NumberOfPosts
            && j.YearExperienceRequired == job.YearExperienceRequired && j.FrenchLevel == job.FrenchLevel
            && job.EnglishLevel == job.EnglishLevel && j.Graduate == job.Graduate).FirstAsync();
        }
        //public async Task<IEnumerable<TmJobJob>> GetJobByRecruiterCode(int recCode)
        //{
        //    return await _context.TmJobJobs.Where(j => j.RecruiterCode == recCode).ToListAsync();
        //}

        public async Task<IEnumerable<JobDtoCreateTransformed3>> GetJobByRecruiterCode(int recCode)
        {
            var job = from j in _context.TmJobJobs
                      join d in _context.TmDmnDomains
                      on j.DomainCode equals d.DomainCode
                      join r in _context.TmRegRegions
                      on j.RegionCode equals r.RegionCode
                      join tc in _context.TcCtrTypeContracts
                      on j.CtrCode equals tc.CtrCode
                      where j.RecruiterCode == recCode
                      select new JobDtoCreateTransformed3
                      {
                          JobCode= j.JobCode,
                          JobName = j.JobName,
                          JobDesc = j.JobDesc,
                          JobLevel = j.JobLevel,
                          JobExpDate = j.JobExpDate,
                          JobMode = j.JobMode,
                          DomainName = d.DomainName,
                          RegionName = r.RegionName,
                          RecruiterCode = j.RecruiterCode,
                          CtrName = tc.CtrLabel,
                          NumberOfPosts = j.NumberOfPosts,
                          YearExperienceRequired = j.YearExperienceRequired,
                          FrenchLevel = j.FrenchLevel,
                          EnglishLevel = j.EnglishLevel,
                          Graduate = j.Graduate
                      };
            var jobs = job.ToList();
            return jobs;

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
