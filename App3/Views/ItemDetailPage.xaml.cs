using SimpleCommerce.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SimpleCommerce.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}