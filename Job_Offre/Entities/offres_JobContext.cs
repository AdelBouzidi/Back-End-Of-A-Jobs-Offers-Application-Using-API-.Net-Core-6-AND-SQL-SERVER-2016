using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Job_Offre.Entities
{
    public partial class offres_JobContext : DbContext
    {
        public offres_JobContext()
        {
        }

        public offres_JobContext(DbContextOptions<offres_JobContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TcCtrTypeContract> TcCtrTypeContracts { get; set; } = null!;
        public virtual DbSet<TcGdrGender> TcGdrGenders { get; set; } = null!;
        public virtual DbSet<TmCndCandidate> TmCndCandidates { get; set; } = null!;
        public virtual DbSet<TmCotCountry> TmCotCountries { get; set; } = null!;
        public virtual DbSet<TmDmnDomain> TmDmnDomains { get; set; } = null!;
        public virtual DbSet<TmExpExperience> TmExpExperiences { get; set; } = null!;
        public virtual DbSet<TmFrmFormation> TmFrmFormations { get; set; } = null!;
        public virtual DbSet<TmJobJob> TmJobJobs { get; set; } = null!;
        public virtual DbSet<TmPrfPreference> TmPrfPreferences { get; set; } = null!;
        public virtual DbSet<TmRecRecruiter> TmRecRecruiters { get; set; } = null!;
        public virtual DbSet<TmRegRegion> TmRegRegions { get; set; } = null!;
        public virtual DbSet<TmRolRole> TmRolRoles { get; set; } = null!;
        public virtual DbSet<TmSklSkill> TmSklSkills { get; set; } = null!;
        public virtual DbSet<TmUsrUserAccount> TmUsrUserAccounts { get; set; } = null!;
        public virtual DbSet<TrAppApply> TrAppApplies { get; set; } = null!;
        public virtual DbSet<TrCskCandidateSkill> TrCskCandidateSkills { get; set; } = null!;
        public virtual DbSet<TrHexHaveExperience> TrHexHaveExperiences { get; set; } = null!;
        public virtual DbSet<TrHfrHaveFormation> TrHfrHaveFormations { get; set; } = null!;
        public virtual DbSet<TrHprHavePreference> TrHprHavePreferences { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see SSPI https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-SIA6P18\\SQLEXPRESS;Initial Catalog=offres_Job;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TcCtrTypeContract>(entity =>
            {
                entity.HasKey(e => e.CtrCode)
                    .HasName("PK__TC_CTR_T__8D9DFA9013A4182E");

                entity.ToTable("TC_CTR_Type_Contract");

                entity.Property(e => e.CtrCode).HasColumnName("Ctr_Code");

                entity.Property(e => e.CtrLabel)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Ctr_Label");
            });

            modelBuilder.Entity<TcGdrGender>(entity =>
            {
                entity.HasKey(e => e.GenderCode)
                    .HasName("PK__TC_GDR_G__6E98095A7392AAAB");

                entity.ToTable("TC_GDR_Gender");

                entity.Property(e => e.GenderCode).HasColumnName("Gender_Code");

                entity.Property(e => e.GndLabel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("GND_Label");
            });

            modelBuilder.Entity<TmCndCandidate>(entity =>
            {
                entity.HasKey(e => e.CandidateCode)
                    .HasName("PK__TM_CND_C__3EE49F6C778653DF");

                entity.ToTable("TM_CND_Candidate");

                entity.Property(e => e.CandidateCode).HasColumnName("Candidate_Code");

                entity.Property(e => e.CandidateAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Candidate_Adress");

                entity.Property(e => e.CandidateDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Candidate_Desc");

                entity.Property(e => e.CandidateFname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Candidate_Fname");

                entity.Property(e => e.CandidateLname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Candidate_Lname");

                entity.Property(e => e.CandidateMs).HasColumnName("Candidate_MS");

                entity.Property(e => e.CandidatePhone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Candidate_Phone");

                entity.Property(e => e.GenderCode).HasColumnName("Gender_Code");

                entity.Property(e => e.UserCode).HasColumnName("User_Code");

                entity.HasOne(d => d.GenderCodeNavigation)
                    .WithMany(p => p.TmCndCandidates)
                    .HasForeignKey(d => d.GenderCode)
                    .HasConstraintName("FK__TM_CND_Ca__Gende__607251E5");

                entity.HasOne(d => d.UserCodeNavigation)
                    .WithMany(p => p.TmCndCandidates)
                    .HasForeignKey(d => d.UserCode)
                    .HasConstraintName("FK__TM_CND_Ca__User___6166761E");
            });

            modelBuilder.Entity<TmCotCountry>(entity =>
            {
                entity.HasKey(e => e.CountryCode)
                    .HasName("PK__TM_COT_C__A0D39295D052C666");

                entity.ToTable("TM_COT_Country");

                entity.Property(e => e.CountryCode).HasColumnName("Country_Code");

                entity.Property(e => e.CountryName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Country_Name");
            });

            modelBuilder.Entity<TmDmnDomain>(entity =>
            {
                entity.HasKey(e => e.DomainCode)
                    .HasName("PK__TM_DMN_D__F4C423C81EAD1AB1");

                entity.ToTable("TM_DMN_Domain");

                entity.Property(e => e.DomainCode).HasColumnName("Domain_Code");

                entity.Property(e => e.DomainDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Domain_Desc");

                entity.Property(e => e.DomainName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Domain_Name");
            });

            modelBuilder.Entity<TmExpExperience>(entity =>
            {
                entity.HasKey(e => e.ExpCode)
                    .HasName("PK__TM_EXP_E__2C0289970776EDC8");

                entity.ToTable("TM_EXP_Experience");

                entity.Property(e => e.ExpCode).HasColumnName("Exp_Code");

                entity.Property(e => e.ExpCompany)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Exp_Company");

                entity.Property(e => e.ExpDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Exp_Desc");

                entity.Property(e => e.ExpEdate)
                    .HasColumnType("date")
                    .HasColumnName("Exp_Edate");

                entity.Property(e => e.ExpInProg).HasColumnName("Exp_In_Prog");

                entity.Property(e => e.ExpName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Exp_Name");

                entity.Property(e => e.ExpSdate)
                    .HasColumnType("date")
                    .HasColumnName("Exp_Sdate");
            });

            modelBuilder.Entity<TmFrmFormation>(entity =>
            {
                entity.HasKey(e => e.FormCode)
                    .HasName("PK__TM_FRM_F__F4C7A90CAB2C1BA4");

                entity.ToTable("TM_FRM_Formation");

                entity.Property(e => e.FormCode).HasColumnName("Form_Code");

                entity.Property(e => e.FormDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Form_Desc");

                entity.Property(e => e.FormEdate)
                    .HasColumnType("date")
                    .HasColumnName("Form_Edate");

                entity.Property(e => e.FormGrad)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Form_Grad");

                entity.Property(e => e.FormInProg).HasColumnName("Form_In_Prog");

                entity.Property(e => e.FormName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Form_Name");

                entity.Property(e => e.FormSdate)
                    .HasColumnType("date")
                    .HasColumnName("Form_Sdate");

                entity.Property(e => e.SchoolName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("School_Name");
            });

            modelBuilder.Entity<TmJobJob>(entity =>
            {
                entity.HasKey(e => e.JobCode)
                    .HasName("PK__TM_JOB_J__AF619D5B62DABAF9");

                entity.ToTable("TM_JOB_Job");

                entity.Property(e => e.JobCode).HasColumnName("Job_Code");

                entity.Property(e => e.CtrCode).HasColumnName("Ctr_Code");

                entity.Property(e => e.DomainCode).HasColumnName("Domain_Code");

                entity.Property(e => e.EnglishLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("English_Level");

                entity.Property(e => e.FrenchLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("French_Level");

                entity.Property(e => e.Graduate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.JobDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Job_Desc");

                entity.Property(e => e.JobExpDate)
                    .HasColumnType("date")
                    .HasColumnName("Job_Exp_Date");

                entity.Property(e => e.JobLevel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Job_Level");

                entity.Property(e => e.JobMode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Job_Mode");

                entity.Property(e => e.JobName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Job_name");

                entity.Property(e => e.NumberOfPosts).HasColumnName("number_of_posts");

                entity.Property(e => e.RecruiterCode).HasColumnName("Recruiter_Code");

                entity.Property(e => e.RegionCode).HasColumnName("Region_Code");

                entity.Property(e => e.YearExperienceRequired).HasColumnName("year_experience_required");

                entity.HasOne(d => d.CtrCodeNavigation)
                    .WithMany(p => p.TmJobJobs)
                    .HasForeignKey(d => d.CtrCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TM_JOB_Jo__Ctr_C__02C769E9");

                entity.HasOne(d => d.DomainCodeNavigation)
                    .WithMany(p => p.TmJobJobs)
                    .HasForeignKey(d => d.DomainCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TM_JOB_Jo__Domai__634EBE90");

                entity.HasOne(d => d.RecruiterCodeNavigation)
                    .WithMany(p => p.TmJobJobs)
                    .HasForeignKey(d => d.RecruiterCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TM_JOB_Jo__Recru__6442E2C9");

                entity.HasOne(d => d.RegionCodeNavigation)
                    .WithMany(p => p.TmJobJobs)
                    .HasForeignKey(d => d.RegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TM_JOB_Jo__Regio__65370702");
            });

            modelBuilder.Entity<TmPrfPreference>(entity =>
            {
                entity.HasKey(e => e.PrefCode)
                    .HasName("PK__TM_PRF_P__E99A79DC2C71D99E");

                entity.ToTable("TM_PRF_Preference");

                entity.Property(e => e.PrefCode).HasColumnName("Pref_Code");

                entity.Property(e => e.CtrCode).HasColumnName("Ctr_Code");

                entity.Property(e => e.DesiredSalary).HasColumnName("Desired_Salary");

                entity.Property(e => e.PrefMobility)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Pref_Mobility");

                entity.HasOne(d => d.CtrCodeNavigation)
                    .WithMany(p => p.TmPrfPreferences)
                    .HasForeignKey(d => d.CtrCode)
                    .HasConstraintName("FK__TM_PRF_Pr__Ctr_C__01D345B0");
            });

            modelBuilder.Entity<TmRecRecruiter>(entity =>
            {
                entity.HasKey(e => e.RecruiterCode)
                    .HasName("PK__TM_REC_R__6F9DC74E221195DE");

                entity.ToTable("TM_REC_Recruiter");

                entity.Property(e => e.RecruiterCode).HasColumnName("Recruiter_Code");

                entity.Property(e => e.GenderCode).HasColumnName("Gender_Code");

                entity.Property(e => e.RecruiterAdress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Recruiter_Adress");

                entity.Property(e => e.RecruiterDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Recruiter_Desc");

                entity.Property(e => e.RecruiterFname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Recruiter_Fname");

                entity.Property(e => e.RecruiterLname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Recruiter_Lname");

                entity.Property(e => e.RecruiterPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Recruiter_Phone");

                entity.Property(e => e.UserCode).HasColumnName("User_Code");

                entity.HasOne(d => d.GenderCodeNavigation)
                    .WithMany(p => p.TmRecRecruiters)
                    .HasForeignKey(d => d.GenderCode)
                    .HasConstraintName("FK__TM_REC_Re__Gende__671F4F74");

                entity.HasOne(d => d.UserCodeNavigation)
                    .WithMany(p => p.TmRecRecruiters)
                    .HasForeignKey(d => d.UserCode)
                    .HasConstraintName("FK__TM_REC_Re__User___681373AD");
            });

            modelBuilder.Entity<TmRegRegion>(entity =>
            {
                entity.HasKey(e => e.RegionCode)
                    .HasName("PK__TM_REG_R__63C1AD9CE062BF7E");

                entity.ToTable("TM_REG_Region");

                entity.Property(e => e.RegionCode).HasColumnName("Region_Code");

                entity.Property(e => e.CountryCode).HasColumnName("Country_Code");

                entity.Property(e => e.RegionName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Region_Name");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.TmRegRegions)
                    .HasForeignKey(d => d.CountryCode)
                    .HasConstraintName("FK__TM_REG_Re__Count__690797E6");
            });

            modelBuilder.Entity<TmRolRole>(entity =>
            {
                entity.HasKey(e => e.RoleCode);

                entity.ToTable("TM_ROL_Role");

                entity.Property(e => e.RoleCode).HasColumnName("Role_Code");

                entity.Property(e => e.RoleLabel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Role_Label");
            });

            modelBuilder.Entity<TmSklSkill>(entity =>
            {
                entity.HasKey(e => e.SkillCode)
                    .HasName("PK__TM_SKL_S__6D3858DDEA2573DC");

                entity.ToTable("TM_SKL_Skill");

                entity.Property(e => e.SkillCode).HasColumnName("Skill_Code");

                entity.Property(e => e.SkillDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Skill_Desc");

                entity.Property(e => e.SkillName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Skill_Name");

                entity.HasMany(d => d.JobCodes)
                    .WithMany(p => p.SkillCodes)
                    .UsingEntity<Dictionary<string, object>>(
                        "TrRtoRelatedTo",
                        l => l.HasOne<TmJobJob>().WithMany().HasForeignKey("JobCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TR_RTO_Re__Job_C__7C1A6C5A"),
                        r => r.HasOne<TmSklSkill>().WithMany().HasForeignKey("SkillCode").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TR_RTO_Re__Skill__7A3223E8"),
                        j =>
                        {
                            j.HasKey("SkillCode", "JobCode");

                            j.ToTable("TR_RTO_Related_To");

                            j.IndexerProperty<int>("SkillCode").HasColumnName("Skill_Code");

                            j.IndexerProperty<int>("JobCode").HasColumnName("Job_Code");
                        });
            });

            modelBuilder.Entity<TmUsrUserAccount>(entity =>
            {
                entity.HasKey(e => e.UserCode)
                    .HasName("PK__TM_USR_U__3E6D1F35585785BE");

                entity.ToTable("TM_USR_User_Account");

                entity.Property(e => e.UserCode).HasColumnName("User_Code");

                entity.Property(e => e.RoleCode).HasColumnName("Role_Code");

                entity.Property(e => e.UserName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPw)
                    .HasMaxLength(10)
                    .HasColumnName("User_Pw")
                    .IsFixedLength();

                entity.HasOne(d => d.RoleCodeNavigation)
                    .WithMany(p => p.TmUsrUserAccounts)
                    .HasForeignKey(d => d.RoleCode)
                    .HasConstraintName("FK_USR_User_Account");
            });

            modelBuilder.Entity<TrAppApply>(entity =>
            {
                entity.HasKey(e => new { e.JobCode, e.CandidateCode });

                entity.ToTable("TR_APP_Apply");

                entity.Property(e => e.JobCode).HasColumnName("Job_Code");

                entity.Property(e => e.CandidateCode).HasColumnName("Candidate_Code");

                entity.Property(e => e.ApplyDate)
                    .HasColumnType("date")
                    .HasColumnName("Apply_Date");

                entity.HasOne(d => d.CandidateCodeNavigation)
                    .WithMany(p => p.TrAppApplies)
                    .HasForeignKey(d => d.CandidateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_APP_Ap__Candi__6AEFE058");

                entity.HasOne(d => d.JobCodeNavigation)
                    .WithMany(p => p.TrAppApplies)
                    .HasForeignKey(d => d.JobCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_APP_Ap__Job_C__6BE40491");
            });

            modelBuilder.Entity<TrCskCandidateSkill>(entity =>
            {
                entity.HasKey(e => new { e.SkillCode, e.CandidateCode });

                entity.ToTable("TR_CSK_Candidate_Skill");

                entity.Property(e => e.SkillCode).HasColumnName("Skill_Code");

                entity.Property(e => e.CandidateCode).HasColumnName("Candidate_Code");

                entity.Property(e => e.SkillLevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Skill_Level");

                entity.HasOne(d => d.CandidateCodeNavigation)
                    .WithMany(p => p.TrCskCandidateSkills)
                    .HasForeignKey(d => d.CandidateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_CSK_Ca__Candi__6CD828CA");

                entity.HasOne(d => d.SkillCodeNavigation)
                    .WithMany(p => p.TrCskCandidateSkills)
                    .HasForeignKey(d => d.SkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_CSK_Ca__Skill__6DCC4D03");
            });

            modelBuilder.Entity<TrHexHaveExperience>(entity =>
            {
                entity.HasKey(e => new { e.ExpCode, e.CandidateCode, e.SkillCode, e.DomainCode });

                entity.ToTable("TR_HEX_Have_Experience");

                entity.Property(e => e.ExpCode).HasColumnName("Exp_Code");

                entity.Property(e => e.CandidateCode).HasColumnName("Candidate_Code");

                entity.Property(e => e.SkillCode).HasColumnName("Skill_Code");

                entity.Property(e => e.DomainCode).HasColumnName("Domain_Code");

                entity.Property(e => e.CountryCode).HasColumnName("Country_Code");

                entity.Property(e => e.RegionCode).HasColumnName("Region_Code");

                entity.HasOne(d => d.CandidateCodeNavigation)
                    .WithMany(p => p.TrHexHaveExperiences)
                    .HasForeignKey(d => d.CandidateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HEX_Ha__Candi__6EC0713C");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.TrHexHaveExperiences)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HEX_Ha__Count__6FB49575");

                entity.HasOne(d => d.DomainCodeNavigation)
                    .WithMany(p => p.TrHexHaveExperiences)
                    .HasForeignKey(d => d.DomainCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HEX_Ha__Domai__70A8B9AE");

                entity.HasOne(d => d.ExpCodeNavigation)
                    .WithMany(p => p.TrHexHaveExperiences)
                    .HasForeignKey(d => d.ExpCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HEX_Ha__Exp_C__719CDDE7");

                entity.HasOne(d => d.RegionCodeNavigation)
                    .WithMany(p => p.TrHexHaveExperiences)
                    .HasForeignKey(d => d.RegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HEX_Ha__Regio__72910220");

                entity.HasOne(d => d.SkillCodeNavigation)
                    .WithMany(p => p.TrHexHaveExperiences)
                    .HasForeignKey(d => d.SkillCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HEX_Ha__Skill__7B264821");
            });

            modelBuilder.Entity<TrHfrHaveFormation>(entity =>
            {
                entity.HasKey(e => new { e.FormCode, e.CandidateCode });

                entity.ToTable("TR_HFR_Have_Formation");

                entity.Property(e => e.FormCode).HasColumnName("Form_Code");

                entity.Property(e => e.CandidateCode).HasColumnName("Candidate_Code");

                entity.Property(e => e.CountryCode).HasColumnName("Country_Code");

                entity.Property(e => e.RegionCode).HasColumnName("Region_Code");

                entity.HasOne(d => d.CandidateCodeNavigation)
                    .WithMany(p => p.TrHfrHaveFormations)
                    .HasForeignKey(d => d.CandidateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HFR_Ha__Candi__73852659");

                entity.HasOne(d => d.CountryCodeNavigation)
                    .WithMany(p => p.TrHfrHaveFormations)
                    .HasForeignKey(d => d.CountryCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HFR_Ha__Count__74794A92");

                entity.HasOne(d => d.FormCodeNavigation)
                    .WithMany(p => p.TrHfrHaveFormations)
                    .HasForeignKey(d => d.FormCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HFR_Ha__Form___756D6ECB");

                entity.HasOne(d => d.RegionCodeNavigation)
                    .WithMany(p => p.TrHfrHaveFormations)
                    .HasForeignKey(d => d.RegionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HFR_Ha__Regio__76619304");
            });

            modelBuilder.Entity<TrHprHavePreference>(entity =>
            {
                entity.HasKey(e => new { e.CandidateCode, e.PrefCode, e.DomainCode })
                    .HasName("PK_Tr_HPR_Have_Preference");

                entity.ToTable("TR_HPR_Have_Preference");

                entity.Property(e => e.CandidateCode).HasColumnName("Candidate_Code");

                entity.Property(e => e.PrefCode).HasColumnName("Pref_Code");

                entity.Property(e => e.DomainCode).HasColumnName("Domain_Code");

                entity.HasOne(d => d.CandidateCodeNavigation)
                    .WithMany(p => p.TrHprHavePreferences)
                    .HasForeignKey(d => d.CandidateCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HPR_Ha__Candi__7755B73D");

                entity.HasOne(d => d.DomainCodeNavigation)
                    .WithMany(p => p.TrHprHavePreferences)
                    .HasForeignKey(d => d.DomainCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HPR_Ha__Domai__7849DB76");

                entity.HasOne(d => d.PrefCodeNavigation)
                    .WithMany(p => p.TrHprHavePreferences)
                    .HasForeignKey(d => d.PrefCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TR_HPR_Ha__Pref___793DFFAF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
