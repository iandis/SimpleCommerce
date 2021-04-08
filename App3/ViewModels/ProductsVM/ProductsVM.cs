using SimpleCommerce.Models;
using SimpleCommerce.Services.ProductService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleCommerce.ViewModels.ProductsVM
{
    public class ProductsVM : BaseViewModel
    {
        ObservableCollection<Products> _products = new ObservableCollection<Products>();
        public ProductsVM()
        {

        }

        public ObservableCollection<Products> Products
        {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public ICommand LoadCommand => new Command(async () => await Load());
        public ICommand ClearCommand => new Command(() => Products.Clear());
        async Task Load()
        {
            if (IsBusy) return;

            IsBusy = true;

            Products.Clear();
            var prods = await ProductService.Instance.GetProducts().ConfigureAwait(false);

            if(prods.Count() > 0)
            {
                foreach (var p in prods)
                    Products.Add(p);
            }

            IsBusy = false;
            IsRefreshing = false;
        }
    }
}
