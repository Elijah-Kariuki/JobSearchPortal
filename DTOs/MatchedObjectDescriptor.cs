using JobSearchPortal.Models;

namespace JobSearchPortal.DTOs
{
    public class MatchedObjectDescriptor
    {

        public int PositionId { get; set; }
        public string PositionTitle { get; set; }
        public string PositionURI { get; set; }
        public List<string> ApplyURL { get; set; }
        public string PositionLocationDisplay { get; set; }
        public List<PositionLocation> PositionLocation { get; set; }
        public string OrganizationName { get; set; }
        public string DepartmentName { get; set; }
        public List<JobCategory> JobCategory { get; set; }
        public List<JobGrade> JobGrade { get; set; }
        public List<PositionSchedule> PositionSchedule { get; set; }
        public List<PositionOfferingType> PositionOfferingType { get; set; }
        public string QualificationSummary { get; set; }
        public List<PositionRemuneration> PositionRemuneration { get; set; }
        public DateTime PositionStartDate { get; set; }
        public DateTime PositionEndDate { get; set; }
        public DateTime PublicationStartDate { get; set; }
        public DateTime ApplicationCloseDate { get; set; }
        public List<PositionFormattedDescription> PositionFormattedDescription { get; set; }
        public UserArea UserArea { get; set; }
    }
}
