using JobSearchPortal.DTOs;

namespace JobSearchPortal.Interfaces
{
    public interface IJobSearchServices
    {
        Task<USAJobsResponse> GetJobSearchResultAsync(SearchParameters searchParameters);
    }
}
