﻿namespace Job_Offre.Models.Dtos.FormationDtos
{
    public class FormationReadDto
    {
        public string FormGrad { get; set; } = null!;
        public string FormName { get; set; } = null!;
        public string? FormDesc { get; set; }
        public string SchoolName { get; set; } = null!;
        public bool? FormInProg { get; set; }
        public DateTime FormSdate { get; set; }
        public DateTime? FormEdate { get; set; }
    }
}