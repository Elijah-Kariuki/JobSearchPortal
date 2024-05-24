namespace JobSearchPortal.DTOs
{
    public class SearchResult
    {
        public int SearchResultCount { get; set; }
        public int SearchResultCountAll { get; set; }
        public List<SearchResultItem> SearchResultItems { get; set; }
        public UserArea UserArea { get; set; }
    }
}
