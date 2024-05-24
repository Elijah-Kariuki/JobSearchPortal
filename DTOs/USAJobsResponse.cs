using System.Runtime.InteropServices;

namespace JobSearchPortal.DTOs
{
    public class USAJobsResponse
    {
        public string LanguageCode { get; set; }
        public SearchParameters SearchParameters { get; set; }
        public SearchResult SearchResult { get; set; }
    }
}
