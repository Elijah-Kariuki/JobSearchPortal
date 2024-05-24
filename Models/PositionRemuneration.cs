using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobSearchPortal.Models
{
    public class PositionRemuneration
    {
        [Key]
        public int Id { get; set; }
        public string MinimumRange { get; set; }
        public string MaximumRange { get; set; }
        public string Description { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
