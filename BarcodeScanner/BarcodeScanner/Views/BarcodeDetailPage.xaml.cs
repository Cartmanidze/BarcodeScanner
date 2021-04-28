using BarcodeScanner.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BarcodeScanner.Views
{
    public partial class BarcodeDetailPage : ContentPage
    {
        public BarcodeDetailPage()
        {
            InitializeComponent();
            BindingContext = new BarcodeDetailViewModel();
        }
    }
}