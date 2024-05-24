using System.Threading.Tasks;
using JobSearchPortal.Models;
namespace JobSearchPortal.Interfaces
{
    public interface IJobSearchPortalRepository
    {
        Task<IEnumerable<Job>> GetJobsAsync();
        Task<Job> GetJobAsync(int id);
        Task<Job> AddJobAsync(Job job);
        Task<Job> UpdateJobAsync(Job job);
        Task<Job> DeleteJobAsync(int id);

    }
}
