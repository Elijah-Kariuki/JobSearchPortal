using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace JobSearchPortal.Models
{
    public class PositionLocation
    {
        [Key]
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string CountryCode { get; set; }
        public string CountrySubdivisionCode { get; set; }
        public string CityName { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        [ForeignKey("Job")]
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
