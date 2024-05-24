using Microsoft.AspNetCore.Mvc;
using JobSearchPortal.Interfaces;
using JobSearchPortal.DTOs;
using System.Threading.Tasks;

namespace JobSearchPortal.Controllers
{
    public class JobSearchController : Controller
    {
        private readonly IJobSearchServices _jobSearchService;

        public JobSearchController(IJobSearchServices jobSearchService)
        {
            _jobSearchService = jobSearchService;
        }

        public IActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Search(SearchParameters searchParameters)
        {
            try
            {
                var jobs = await _jobSearchService.GetJobSearchResultAsync(searchParameters);
                return View("SearchResults", jobs);
            }
            catch (Exception ex)
            {
                return View("Error", ex.Message);
            }
        }
    }
}
