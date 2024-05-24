using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobSearchPortal.DTOs;
namespace JobSearchPortal.Models
{
    public class Refiner
    {
        [Key]
        public int Id { get; set; }
        public string RefinementName { get; set; }
        public string RefineCount { get; set; }
        public string RefinementToken { get; set; }
        public string RefinementValue { get; set; }

        public int UserAreaId { get; set; }
        public UserArea UserArea { get; set; }
    }
}
