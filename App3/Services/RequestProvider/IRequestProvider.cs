
using System.Net.Http;
using System.Threading.Tasks;

namespace SimpleCommerce.Services.RequestProvider
{
    public interface IRequestProvider
    {
        Task<string> GetAsync(string uri);
        Task<string> PostAsync(string uri, string data);       
        Task<string> PostAsync(string uri, MultipartFormDataContent data = null);
        
    }
}
