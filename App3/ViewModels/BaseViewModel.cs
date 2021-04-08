using SimpleCommerce.Models;
using SimpleCommerce.Services;
using Xamarin.Forms;

namespace SimpleCommerce.ViewModels
{
    public class BaseViewModel : BaseModel
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();
        bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        string title = string.Empty;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        bool canLoadMore = false;
        public bool CanLoadMore
        {
            get { return canLoadMore; }
            set { SetProperty(ref canLoadMore, value); }
        }
        bool isRefreshing = false;
        public bool IsRefreshing
        {
            get { return isRefreshing; }
            set { SetProperty(ref isRefreshing, value); }
        }
    }
}
