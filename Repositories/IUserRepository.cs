﻿using Job_Offre.Entities;
using Job_Offre.Models.Dtos.PreferenceDtos;

namespace Job_Offre.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<TmCndCandidate>> GetCandidatesAsync();
        Task<TmUsrUserAccount> GetUserByEmail(string mail, int role);
        Task<TmUsrUserAccount> GetUserByEmail(string mail, string role);
        Task<TmUsrUserAccount> GetCandidateByEmail(string mail);
        Task<TmUsrUserAccount> GetRecruiterByEmail(string mail);
        //Task AddUserAsync(TmUsrUserAccount user);
        Task<TmUsrUserAccount> AddUserAsync(TmUsrUserAccount user);
        Task<TmUsrUserAccount> GetUserAsync();
        //Task<TmRecRecruiter> RecruiterExistAsync(string mail);
        Task<bool> RecruiterExistAsync(string mail);
        Task AddRecruiterAsync(TmRecRecruiter recruiter);
        Task<TmUsrUserAccount> GetUserByCode(int code);
        Task<TmRecRecruiter> GetRecruiterByAdressMail(string mail);
        Task<TmCndCandidate> GetCandidateByAdressMail(string mail);
        Task<bool> CandidateExistAsync(string mail);
        Task AddCandidateAsync(TmCndCandidate candidate);
        Task<bool> SaveChangesAsync();
        Task<object> GetCandidateExp(string mail);
        Task<object> GetCandidateForm(string mail);
        Task<object> GetCandidateSkill(string mail);
        //Task<object> GetCandidatePref(string mail);
        Task<PreferenceDtoTransformed> GetCandidatePref(string mail);
        Task<TmRegRegion> GetRegionByCodeReg(int code);
        Task<TmCotCountry> GetCountryByCodeCot(int code);
        Task<TmSklSkill> GetskillByCodeskill(int code);
        Task<TmDmnDomain> GetDomainByCodesDom(int code);
        Task<object> GetCandidateForm2(string mail);
    }
}