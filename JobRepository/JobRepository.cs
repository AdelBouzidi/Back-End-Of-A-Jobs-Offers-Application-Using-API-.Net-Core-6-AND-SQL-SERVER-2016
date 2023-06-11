using Job_Offre.Entities;
using Job_Offre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
//using System.Data.Entity;
using System.Net.Mail;

namespace Job_Offre.JobRepository
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
        public async Task<TmUsrUserAccount> GetUserByEmail(string mail, string role) 
        {
            var user = from cnd in _context.TmCndCandidates
                       join usr in _context.TmUsrUserAccounts
                       on cnd.UserCode equals usr.UserCode
                       where (cnd.CandidateAdress == mail)
                       select new TmUsrUserAccount
                       {
                           UserCode = usr.UserCode,
                           UserName = usr.UserName,
                           UserPw = usr.UserPw,
                           RoleCode = usr.RoleCode,
                       };
            var utilisateur = from rec in _context.TmRecRecruiters
                              join usr in _context.TmUsrUserAccounts
                              on rec.UserCode equals usr.UserCode
                              where (rec.RecruiterAdress == mail)
                              select new TmUsrUserAccount
                              {
                                  UserCode = usr.UserCode,
                                  UserName = usr.UserName,
                                  UserPw = usr.UserPw,
                                  RoleCode = usr.RoleCode,
                              };
            if (role == "candidate")
            {
                return await user.FirstAsync();
            }
            if (role == "recruiter")
            {
                return await utilisateur.FirstAsync();
            }
            throw new Exception("Please indicate the role correctly (recruiter/candidate)");
        }
        public async Task<TmUsrUserAccount> GetUserByCode(int code)
        {
            return await _context.TmUsrUserAccounts.Where(u => u.UserCode == code).FirstOrDefaultAsync();
        }


        public async Task<TmUsrUserAccount> GetRecruiterByEmail(string mail)
        {
            var utilisateur = from rec in _context.TmRecRecruiters
                              join usr in _context.TmUsrUserAccounts
                              on rec.UserCode equals usr.UserCode
                              where (rec.RecruiterAdress == mail)
                              select new TmUsrUserAccount
                              {
                                  UserCode = usr.UserCode,
                                  UserName = usr.UserName,
                                  UserPw = usr.UserPw,
                                  RoleCode = usr.RoleCode,
                              };
            return await utilisateur.FirstAsync();
        }
        public async Task<TmUsrUserAccount> GetCandidateByEmail(string mail)
        {
            var user = from cnd in _context.TmCndCandidates
                       join usr in _context.TmUsrUserAccounts
                       on cnd.UserCode equals usr.UserCode
                       where (cnd.CandidateAdress == mail)
                       select new TmUsrUserAccount
                       {
                           UserCode = usr.UserCode,
                           UserName = usr.UserName,
                           UserPw = usr.UserPw,
                           RoleCode = usr.RoleCode,
                       };
            return await user.FirstAsync();
        }
        public async Task AddJobAsync(TmJobJob job)
        {

                await _context.TmJobJobs.AddAsync(job);
            //var res = await _context.SaveChangesAsync();
        }
        public async Task<TmUsrUserAccount> GetUserAsync()
        {
            var user = await _context.TmUsrUserAccounts.OrderByDescending(c => c.UserCode).FirstAsync();
            return user;
        }
        public async Task<TmUsrUserAccount> AddUserAsync(TmUsrUserAccount user)
        {
            try
            {
                await _context.TmUsrUserAccounts.AddAsync(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Exeptions AddUserAsync {ex.Message}");
            }
            var userAdded = await GetUserAsync();
            return userAdded;
        }
        public async Task<bool> RecruiterExistAsync(string mail)
        {
            return await _context.TmRecRecruiters.AnyAsync(c => c.RecruiterAdress == mail);
        }
        public async Task AddRecruiterAsync(TmRecRecruiter recruiter)
        {
            await _context.TmRecRecruiters.AddAsync(recruiter);
        }
        public async Task<TmRecRecruiter> GetRecruiterByAdressMail(string mail)
        {
            return await _context.TmRecRecruiters.Where(r => r.RecruiterAdress == mail).FirstOrDefaultAsync();
        }
        public async Task<bool> SaveChangesAsync()
        {
            //return (await _context.SaveChangesAsync() >= 0);
            try
            {
                return (await _context.SaveChangesAsync() >= 0);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(" ******************* Inner Exception ******************* ");
                    Console.WriteLine(String.Concat(ex.InnerException.StackTrace, ex.InnerException.Message));
                }
                return false;
            }
        }

    }
}
