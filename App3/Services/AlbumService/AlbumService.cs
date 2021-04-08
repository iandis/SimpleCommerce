using SimpleCommerce.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleCommerce.Services.AlbumService
{
    public class AlbumService : IAlbumService
    {
        public static AlbumService Instance { get; } = new AlbumService();
        public async Task<IEnumerable<Album>> GetAlbums(int page = 1)
        {
            List<Album> albums = new List<Album>();

            string uri = "https://jsonplaceholder.typicode.com/albums/" +page+ "/photos";

            string response = await RequestProvider.RequestProvider.Instance.GetAsync(uri);

            if (!string.IsNullOrEmpty(response))
            {                
                JArray resp = JArray.Parse(response);
                foreach(JObject r in resp)
                {
                    var albs = new Album()
                    {
                        Id = (int)r["id"],
                        AlbumId = (int)r["albumId"],
                        AlbumTitle = (string)r["title"],
                        AlbumUrl = (string)r["url"],
                        AlbumThumbnailUrl = (string)r["thumbnailUrl"]                        
                    };
                    albums.Add(albs);
                }
            }
            return await Task.FromResult(albums);
        }
    }
}
