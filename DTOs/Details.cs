using System.ComponentModel.DataAnnotations;

namespace JobSearchPortal.DTOs
{
    public class Details
    {
        public string MajorDuties { get; set; }
        public string Education { get; set; }
        public string Requirements { get; set; }
        public string Evaluations { get; set; }
        public string HowToApply { get; set; }
        public string WhatToExpectNext { get; set; }
        public string RequiredDocuments { get; set; }
        public string Benefits { get; set; }
        public string BenefitsUrl { get; set; }
        public string OtherInformation { get; set; }
        public List<string> KeyRequirements { get; set; }
        public string JobSummary { get; set; }
        public WhoMayApply WhoMayApply { get; set; }
        public string LowGrade { get; set; }
        public string HighGrade { get; set; }
        public string SubAgencyName { get; set; }
        public string OrganizationCode { get; set; }
    }
}
