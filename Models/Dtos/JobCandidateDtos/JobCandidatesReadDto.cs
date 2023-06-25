namespace Job_Offre.Models.Dtos.JobCandidateDtos
{
    public class JobCandidatesReadDto
    {
        public JobDto? Job { get; set; }
        public IEnumerable<CandidateDto>? Candidates { get; set; }

    }
}
