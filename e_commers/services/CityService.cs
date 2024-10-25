using demo.interfaces;

namespace demo.APIS.CityService
{
    public class CityService : ICityService
    {
        private readonly HttpClient _httpClient;
        public CityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<string> GetCityByName(string city)
        {
            Logger.Instance.Log("GetCityByName");
            string url = $"https://api.api-ninjas.com/v1/city?name={city}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("X-Api-Key", "Rck3miuFqudy6Y3F0hQuXsnV08kE12PrdG5yB9Ea");

            var response = await _httpClient.SendAsync(request);
            Logger.Instance.Log("response : "+response);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to retrieve weather data");
            }
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent.ToString();
        }
    }
}

