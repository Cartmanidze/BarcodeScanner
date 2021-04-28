using BarcodeScanner.Models;
using BarcodeScanner.ViewModels;
using Xamarin.Forms;

namespace BarcodeScanner.Views
{
    public partial class NewBarcodePage : ContentPage
    {
        public Barcode Item { get; set; }

        public NewBarcodePage()
        {
            InitializeComponent();
            BindingContext = new NewBarcodeViewModel();
        }
    }
}