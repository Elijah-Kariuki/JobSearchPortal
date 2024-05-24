using System.ComponentModel.DataAnnotations;
namespace JobSearchPortal.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        public string PositionID { get; set; }
        public string PositionTitle { get; set; }
        public string PositionURI { get; set; }
        public string Location { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentName { get; set; }
        public string QualificationSummary { get; set; }
        public DateTime PositionStartDate { get; set; }
        public DateTime PositionEndDate { get; set; }
        public DateTime ApplicationCloseDate { get; set; }


        public ICollection<JobCategory> JobCategories { get; set; }
        public ICollection<JobGrade> JobGrades { get; set; }
        public ICollection<PositionSchedule> PositionSchedules { get; set; }
        public ICollection<PositionOfferingType> PositionOfferingTypes { get; set; }
        public ICollection<PositionRemuneration> PositionRemunerations { get; set; }
        public ICollection<PositionLocation> PositionLocations { get; set; }

    }
}
