using System.Threading.Tasks;
using JobSearchPortal.Models;
using JobSearchPortal.Interfaces;
using JobSearchPortal.Data;
using Microsoft.EntityFrameworkCore;
namespace JobSearchPortal.Repositories
{
    public class JobSearchPortalRepository : IJobSearchPortalRepository
    {
        private readonly ApplicationDbContext _context;

        public JobSearchPortalRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Job>> GetJobsAsync()
        {
            try
            {
                return await _context.Jobs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while retrieving jobs.", ex);
            }
        }

        public async Task<Job> GetJobAsync(int id)
        {
            try
            {
                return await _context.Jobs.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while retrieving job with ID {id}.", ex);
            }
        }

        public async Task<Job> AddJobAsync(Job job)
        {
            try
            {
                _context.Jobs.Add(job);
                await _context.SaveChangesAsync();
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception("Error occurred while adding job.", ex);
            }
        }

        public async Task<Job> UpdateJobAsync(Job job)
        {
            try
            {
                _context.Entry(job).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while updating job with ID {job.Id}.", ex);
            }
        }

        public async Task<Job> DeleteJobAsync(int id)
        {
            try
            {
                var job = await _context.Jobs.FindAsync(id);
                if (job == null)
                {
                    return null;
                }
                _context.Jobs.Remove(job);
                await _context.SaveChangesAsync();
                return job;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting job with ID {id}.", ex);
            }
        }
    }
}
