﻿namespace Job_Offre.Models.Dtos.JobDtos
{
    public class JobDtoCreateTransformed
    {
        public string JobName { get; set; } = null!;
        public string JobDesc { get; set; } = null!;
        public string JobLevel { get; set; } = null!;
        public DateTime? JobExpDate { get; set; }
        public string? JobMode { get; set; }
        public int DomainCode { get; set; }
        public string? RegionName { get; set; }
        public int RecruiterCode { get; set; }
        public int CtrCode { get; set; }
        public int NumberOfPosts { get; set; }
        public int YearExperienceRequired { get; set; }
        public string FrenchLevel { get; set; } = null!;
        public string EnglishLevel { get; set; } = null!;
        public string Graduate { get; set; } = null!;
    }
}