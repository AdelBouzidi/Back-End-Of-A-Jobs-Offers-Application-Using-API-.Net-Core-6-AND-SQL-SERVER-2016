using Job_Offre.Entities;
using Job_Offre.Models.Dtos.ExperienceDtos;
using Job_Offre.Models.Dtos.FormationDtos;
using Job_Offre.Models.Dtos.PreferenceDtos;
using Job_Offre.Models.Dtos.SkillDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient.Server;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml.Linq;


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




        public async Task<TmRegRegion> GetRegionByCodeReg(int code)
        {
            return await _context.TmRegRegions.Where(r => r.RegionCode == code).FirstOrDefaultAsync();
        }
        public async Task<TmCotCountry> GetCountryByCodeCot(int code)
        {
            return await _context.TmCotCountries.Where(r => r.CountryCode == code).FirstOrDefaultAsync();
        }
        public async Task<TmSklSkill> GetskillByCodeskill(int code)
        {
            return await _context.TmSklSkills.Where(r => r.SkillCode == code).FirstOrDefaultAsync();
        }
        public async Task<TmDmnDomain> GetDomainByCodesDom(int code)
        {
            return await _context.TmDmnDomains.Where(r => r.DomainCode == code).FirstOrDefaultAsync();
        }

        public async Task<object> GetCandidateForm(string mail)
        {
            var form1 = from cnd in _context.TmCndCandidates
                       join have_form in _context.TrHfrHaveFormations
                       on cnd.CandidateCode equals have_form.CandidateCode
                       where cnd.CandidateAdress == mail
                       select new TrHfrHaveFormation
                       {
                           FormCode = have_form.FormCode,
                           CandidateCode = have_form.CandidateCode,
                           CountryCode = have_form.CountryCode,
                           RegionCode = have_form.RegionCode,
                       };
            var form2 = from f in form1
                       join fr in _context.TmFrmFormations
                       on f.FormCode equals fr.FormCode
                       select new TmFrmFormation
                       {
                           FormCode = fr.FormCode,
                           FormGrad = fr.FormGrad,
                           FormName = fr.FormName,
                           FormDesc = fr.FormDesc,
                           SchoolName = fr.SchoolName,
                           FormInProg = fr.FormInProg,
                           FormSdate = fr.FormSdate,
                           FormEdate = fr.FormEdate,
                       };
            var formation = await form2.Cast<TmFrmFormation>().ToListAsync();
            if (formation.Count == 1)
            {
                return formation.FirstOrDefault();
            }
            return formation;
        }

        //public async Task<object> GetCandidateForm2(string mail)
        //{
        //    var form1 = from cnd in _context.TmCndCandidates
        //                join hf in _context.TrHfrHaveFormations on cnd.CandidateCode equals hf.CandidateCode
        //                join f in _context.TmFrmFormations on hf.FormCode equals f.FormCode
        //                join ct in _context.TmCotCountries on hf.CountryCode equals ct.CountryCode
        //                join rj in _context.TmRegRegions on hf.RegionCode equals rj.RegionCode
        //                where cnd.CandidateAdress == mail
        //                select new FormationDtoTransformed
        //                {
        //                    FormCode = f.FormCode,
        //                    FormGrad = f.FormGrad,
        //                    FormName = f.FormName,
        //                    FormDesc = f.FormDesc,
        //                    SchoolName = f.SchoolName,
        //                    FormInProg = f.FormInProg,
        //                    FormSdate = f.FormSdate,
        //                    FormEdate = f.FormEdate,
        //                    CountryName = ct.CountryName,
        //                    RegionName = rj.RegionName,
        //                };
        //    var formation = await form1.Cast<TmFrmFormation>().ToListAsync();
        //    if (formation.Count == 1)
        //    {
        //        return formation.FirstOrDefault();
        //    }
        //    return formation;
        //}

        public async Task<object> GetCandidateExp(string mail)
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

            if (experience.Count == 1)
            {
                return experience.FirstOrDefault();
            }

            return experience;
        }
        public async Task<object> GetCandidateForm2(string mail)
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

            if (formation.Count == 1)
            {
                return formation.FirstOrDefault();
            }

            return formation;
        }

        public async Task<object> GetCandidateSkill(string mail)
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

            if (skill1.Count == 1)
            {
                return skill1.FirstOrDefault();
            }

            return skill1;
        }

        public async Task<PreferenceDtoTransformed> GetCandidatePref(string mail)
        {
            var pref = from cnd in _context.TmCndCandidates
                       join hp in _context.TrHprHavePreferences on cnd.CandidateCode equals hp.CandidateCode
                       join p in _context.TmPrfPreferences on hp.PrefCode equals p.PrefCode
                       join dm in _context.TmDmnDomains on hp.DomainCode equals dm.DomainCode
                       join tc in _context.TcCtrTypeContracts on p.CtrCode equals tc.CtrCode
                       select new PreferenceDtoTransformed
                       {
                           PrefCode = p.PrefCode,
                           DesiredSalary = p.DesiredSalary,
                           PrefMobility = p.PrefMobility,
                           CtrName = tc.CtrLabel,
                           DomainName = dm.DomainName,
                       };

            return await pref.FirstAsync();

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
