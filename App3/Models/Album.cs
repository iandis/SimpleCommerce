using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCommerce.Models
{
    public class Album : BaseModel
    {
        public int AlbumId { get; set; } = 0;
        public int Id { get; set; } = 0;
        public string AlbumTitle { get; set; } = "";
        public string AlbumUrl { get; set; } = "";
        public string AlbumThumbnailUrl { get; set; } = "";

        public Album()
        {

        }
        public Album(Album album)
        {
            AlbumId = album.AlbumId;
            Id = album.Id;
            AlbumTitle = album.AlbumTitle;
            AlbumUrl = album.AlbumUrl;
            AlbumThumbnailUrl = album.AlbumThumbnailUrl;
        }
    }
}
