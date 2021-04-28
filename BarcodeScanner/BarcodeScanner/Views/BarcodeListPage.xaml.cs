using BarcodeScanner.ViewModels;
using Xamarin.Forms;

namespace BarcodeScanner.Views
{
    public partial class BarcodeListPage : ContentPage
    {
        private readonly BarcodeListViewModel _barcodeListViewModel;
        public BarcodeListPage()
        {
            InitializeComponent();

            BindingContext = _barcodeListViewModel = new BarcodeListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _barcodeListViewModel.OnAppearing();
        }
    }
}