using Job_Offre.Entities;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;


namespace Job_Offre.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly offres_JobContext _context;
        public UserRepository(offres_JobContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<TmUsrUserAccount> GetUserByEmail(string mail, string role)
        {
            var user = from cnd in _context.TmCndCandidates
                       join usr in _context.TmUsrUserAccounts
                       on cnd.UserCode equals usr.UserCode
                       where cnd.CandidateAdress == mail
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
                              where rec.RecruiterAdress == mail
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
                              where rec.RecruiterAdress == mail
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
                       where cnd.CandidateAdress == mail
                       select new TmUsrUserAccount
                       {
                           UserCode = usr.UserCode,
                           UserName = usr.UserName,
                           UserPw = usr.UserPw,
                           RoleCode = usr.RoleCode,
                       };
            return await user.FirstAsync();
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
            catch (Exception ex)
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
        public async Task<bool> CandidateExistAsync(string mail)
        {
            return await _context.TmCndCandidates.AnyAsync(c => c.CandidateAdress == mail);
        }
        public async Task AddRecruiterAsync(TmRecRecruiter recruiter)
        {
            await _context.TmRecRecruiters.AddAsync(recruiter);
        }
        public async Task AddCandidateAsync(TmCndCandidate candidate)
        {
            await _context.TmCndCandidates.AddAsync(candidate);
        }
        public async Task<TmRecRecruiter> GetRecruiterByAdressMail(string mail)
        {
            return await _context.TmRecRecruiters.Where(r => r.RecruiterAdress == mail).FirstOrDefaultAsync();
        }
        public async Task<TmCndCandidate> GetCandidateByAdressMail(string mail)
        {
            return await _context.TmCndCandidates.Where(r => r.CandidateAdress == mail).FirstOrDefaultAsync();
        }

        public Task<IEnumerable<TmCndCandidate>> GetCandidatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TmUsrUserAccount> GetUserByEmail(string mail, int role)
        {
            throw new NotImplementedException();
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
