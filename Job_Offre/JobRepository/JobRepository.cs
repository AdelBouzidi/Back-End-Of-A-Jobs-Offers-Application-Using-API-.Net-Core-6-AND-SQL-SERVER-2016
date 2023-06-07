using Job_Offre.Entities;
using Job_Offre.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace Job_Offre.JobRepository
{
    public class JobRepository : I_JobRepository
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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }
        public async Task AddJobAsync(TmJobJob job)
        {
            try
            {
                await _context.TmJobJobs.AddAsync(job);
            }
            catch(Exception ex)
            {

            }
            //var res = await _context.SaveChangesAsync();
        }
    }
}
