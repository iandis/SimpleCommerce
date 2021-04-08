using SimpleCommerce.ViewModels.ProductsVM;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleCommerce.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsPage : ContentPage
    {
        ProductsVM vm = new ProductsVM();
        public ProductsPage()
        {
            BindingContext = vm;
            InitializeComponent();
            
        }
    }
}