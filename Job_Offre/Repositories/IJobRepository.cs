using Job_Offre.Entities;
using System.Net.Mail;

namespace Job_Offre.Repositories
{
    public interface IJobRepository
    {
        Task<IEnumerable<TmJobJob>> GetJobsAsync();
        //Task<IEnumerable<TmCndCandidate>> GetCandidatesAsync();
        //Task<TmUsrUserAccount> GetUserByEmail(string mail, int role);
        //Task<TmUsrUserAccount> GetUserByEmail(string mail, string role);
        //Task<TmUsrUserAccount> GetCandidateByEmail(string mail);
        //Task<TmUsrUserAccount> GetRecruiterByEmail(string mail);
        Task<TmJobJob> GetJobsByJobCodeAsync(int JCode);
        Task AddJobAsync(TmJobJob job);
        Task<bool> SaveChangesAsync();
        //Task AddUserAsync(TmUsrUserAccount user);
        //Task<TmUsrUserAccount> AddUserAsync(TmUsrUserAccount user);
        //Task<TmUsrUserAccount> GetUserAsync();
        //Task<TmRecRecruiter> RecruiterExistAsync(string mail);
        //Task<bool> RecruiterExistAsync(string mail);
        //Task AddRecruiterAsync(TmRecRecruiter recruiter);
        //Task<TmUsrUserAccount> GetUserByCode(int code);
        //Task<TmRecRecruiter> GetRecruiterByAdressMail(string mail);
    }
}