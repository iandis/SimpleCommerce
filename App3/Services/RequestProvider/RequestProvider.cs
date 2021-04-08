using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCommerce.Services.RequestProvider
{
    public class RequestProvider : IRequestProvider
    {
        private readonly JsonSerializerSettings _serializerSettings;

        private HttpClient _httpClient;
        public static RequestProvider Instance { get; } = new RequestProvider();

        public RequestProvider()
        {
            _serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };

            _serializerSettings.Converters.Add(new StringEnumConverter());
            _httpClient = new HttpClient();
        }
        public async Task<string> GetAsync(string uri)
        {
            //HttpClient _httpClient = new HttpClient();
            var result = await _httpClient.GetAsync(uri).ConfigureAwait(false);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string uri, string data)
        {
            //HttpClient _httpClient = new HttpClient();
            var param = new StringContent(data, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(uri, param).ConfigureAwait(false);
            return await result.Content.ReadAsStringAsync();
        }

        public async Task<string> PostAsync(string uri, MultipartFormDataContent data = null)
        {
            //HttpClient _httpClient = new HttpClient();
            var result = await _httpClient.PostAsync(uri, data).ConfigureAwait(false);
            return await result.Content.ReadAsStringAsync();
        }
    }
}
