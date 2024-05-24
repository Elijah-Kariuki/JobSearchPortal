using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobSearchPortal.Models
{
    public class JobGrade
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
