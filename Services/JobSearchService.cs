using System;
using System.Net.Http;
using System.Threading.Tasks;
using JobSearchPortal.DTOs;
using JobSearchPortal.Interfaces;
using Newtonsoft.Json;
namespace JobSearchPortal.Services
{
    public class JobSearchService : IJobSearchServices
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _baseURL;

        public JobSearchService(HttpClient httpClient, string apiKey, string baseURL)
        {
            _httpClient = httpClient;
            _apiKey = apiKey;
            _baseURL = baseURL;
        }

        /// <summary>
        /// Retrieves job search results asynchronously.
        /// </summary>
        /// <param name="searchParameters">The search parameters.</param>
        /// <returns>The USAJobsResponse containing the job search results.</returns>
        public async Task<USAJobsResponse> GetJobSearchResultAsync(SearchParameters searchParameters)
        {
            try
            {
                string url = $"{_baseURL}?{ToQueryString(searchParameters)}";
                _httpClient.DefaultRequestHeaders.Clear();
                _httpClient.DefaultRequestHeaders.Add("Host", "data.usajobs.gov");
                _httpClient.DefaultRequestHeaders.Add("User-Agent", "elijahkariuki1981@outlook.com");
                _httpClient.DefaultRequestHeaders.Add("Authorization-Key", _apiKey);

                var response = await _httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<USAJobsResponse>(responseContent);
            }
            catch (HttpRequestException ex)
            {
                // Handle HTTP request exception
                throw new Exception("An error occurred while making the HTTP request.", ex);
            }
            catch (JsonException ex)
            {
                // Handle JSON deserialization exception
                throw new Exception("An error occurred while deserializing the JSON response.", ex);
            }
            catch (Exception ex)
            {
                // Handle any other exception
                throw new Exception("An error occurred.", ex);
            }
        }

        private string ToQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + Uri.EscapeDataString(p.GetValue(obj, null).ToString());
            return string.Join("&", properties.ToArray());
        }
    }
}
