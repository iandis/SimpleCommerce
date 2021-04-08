using SimpleCommerce.Models;
using SimpleCommerce.Services.AlbumService;
using SimpleCommerce.Services.RequestProvider;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleCommerce.ViewModels.AlbumVM
{
    public class AlbumVM : BaseViewModel
    {
        ObservableCollection<Album> _albums = new ObservableCollection<Album>(); 
        int page = 1;
        public AlbumVM()
        {
        }

        public ObservableCollection<Album> Albums
        {
            get { return _albums; }
            set { SetProperty(ref _albums, value); }
        }
        public ICommand LoadCommand => new Command(async () => await Load());
        public ICommand LoadMoreCommand => new Command(async () => await LoadMore());

        async Task Load()
        {
            if (IsBusy) return;

            IsBusy = true;

            Albums.Clear(); page = 1;
            var albums = await AlbumService.Instance.GetAlbums(page);
            if(albums.Count() > 0)
            {
                foreach (var a in albums)
                    Albums.Add(a);
                page++;
                if (page <= 100)
                    CanLoadMore = true;
                else
                    CanLoadMore = false;
            }

            IsBusy = false;
        }

        async Task LoadMore()
        {
            if (IsBusy && !CanLoadMore) return;

            IsBusy = true;

            var albums = await AlbumService.Instance.GetAlbums(page);
            if(albums.Count() > 0)
            {
                foreach (var a in albums)
                    Albums.Add(a);
                page++;
                if (page <= 100)
                    CanLoadMore = true;
                else
                    CanLoadMore = false;
            }

            IsBusy = false;
        }
    }
}
