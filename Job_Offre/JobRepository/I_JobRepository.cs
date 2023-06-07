using Job_Offre.Entities;
using System.Net.Mail;

namespace Job_Offre.JobRepository
{
    public interface I_JobRepository
    {
        Task<IEnumerable<TmJobJob>> GetJobsAsync();
        Task<IEnumerable<TmCndCandidate>> GetCandidatesAsync();
        //Task<TmUsrUserAccount> GetUserByEmail(string mail, int role);
        Task<TmUsrUserAccount> GetUserByEmail(string mail, string role);
        Task<TmUsrUserAccount> GetCandidateByEmail(string mail);
        Task<TmUsrUserAccount> GetRecruiterByEmail(string mail);
        Task<TmJobJob> GetJobsByJobCodeAsync(int JCode);
        Task AddJobAsync(TmJobJob job);
        Task<bool> SaveChangesAsync();
    }
}