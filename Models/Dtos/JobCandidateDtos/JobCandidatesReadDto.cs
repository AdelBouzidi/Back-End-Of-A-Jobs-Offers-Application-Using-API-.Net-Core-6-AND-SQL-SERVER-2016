using Job_Offre.Models.Dtos.JobDtos;

namespace Job_Offre.Models.Dtos.JobCandidateDtos
{
    public class JobCandidatesReadDto
    {
        public JobDtoCreateTransformed3? Job { get; set; }
        public IEnumerable<CandidateDto> Candidates { get; set; }

    }
}
