using System.Collections.Generic;
using System.Threading.Tasks;
using SimpleCommerce.Models;
namespace SimpleCommerce.Services.AlbumService
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAlbums(int page = 1);
    }
}
