using System.ComponentModel.DataAnnotations;
using JobSearchPortal.DTOs;
namespace JobSearchPortal.Models
{
    public class JobSearchResult
    {
        [Key]
        public int PositionId { get; set; }
        public  SearchResult SearchResult { get; set; }
    }
}
