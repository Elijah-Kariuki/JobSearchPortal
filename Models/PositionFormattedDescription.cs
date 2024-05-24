using System.ComponentModel.DataAnnotations;
namespace JobSearchPortal.Models
{
    public class PositionFormattedDescription
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Label { get; set; }
        public string LabelDescription { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }

    }
}
