using System;

namespace JobSearchPortal.DTOs
{
    public class SearchParameters
    {
        public string Keyword { get; set; }
        public string PositionTitle { get; set; }
        public decimal? RemunerationMinimumAmount { get; set; }
        public decimal? RemunerationMaximumAmount { get; set; }
        public int? PayGradeHigh { get; set; }
        public int? PayGradeLow { get; set; }
        public string JobCategoryCode { get; set; }
        public string LocationName { get; set; }
        public string PostingChannel { get; set; }
        public string Organization { get; set; }
        public string PositionOfferingTypeCode { get; set; }
        public int? TravelPercentage { get; set; }
        public int? PositionScheduleTypeCode { get; set; }
        public bool? RelocationIndicator { get; set; }
        public int? SecurityClearanceRequired { get; set; }
        public bool? SupervisoryStatus { get; set; }
        public int? DatePosted { get; set; }
        public string JobGradeCode { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
        public int? Page { get; set; }
        public int? ResultsPerPage { get; set; }
        public string WhoMayApply { get; set; }
        public int? Radius { get; set; }
        public string Fields { get; set; }
        public string SalaryBucket { get; set; }
        public string GradeBucket { get; set; }
        public string HiringPath { get; set; }
        public string MissionCriticalTags { get; set; }
        public int? PositionSensitivity { get; set; }
        public bool? RemoteIndicator { get; set; }
    }
}
