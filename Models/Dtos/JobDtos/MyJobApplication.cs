namespace Job_Offre.Models.Dtos.JobDtos
{
    public class MyJobApplication
    {
        public int JobCode { get; set; }
        public string JobName { get; set; } = null!;
        public string JobDesc { get; set; } = null!;
        public string JobLevel { get; set; } = null!;
        public DateTime? JobExpDate { get; set; }
        public string? JobMode { get; set; }
        public string? DomainName { get; set; }
        public string? RegionName { get; set; }
        public string? RecruiterAdress { get; set; }
        public string? RecruiterFName { get; set; }
        public string? RecruiterLName { get; set; }
        public string? CtrName { get; set; }
        public int NumberOfPosts { get; set; }
        public int YearExperienceRequired { get; set; }
        public string FrenchLevel { get; set; } = null!;
        public string EnglishLevel { get; set; } = null!;
        public string Graduate { get; set; } = null!;
        public DateTime ApplyDate { get; set; }
    }
}
