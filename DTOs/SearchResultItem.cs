namespace JobSearchPortal.DTOs
{
    public class SearchResultItem
    {
        public MatchedObjectDescriptor MatchedObjectDescriptor { get; set; }
        public string MatchedObjectId { get; set; }
        public float RelevanceRank { get; set; }
    }
}
