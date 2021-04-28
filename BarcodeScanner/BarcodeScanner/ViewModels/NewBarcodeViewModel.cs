using BarcodeScanner.Models;
using Xamarin.Forms;
using ZXing.Mobile;

namespace BarcodeScanner.ViewModels
{
    public class NewBarcodeViewModel : BaseViewModel
    {
        private readonly MobileBarcodeScanner _scanner;

        public NewBarcodeViewModel()
        {
            _scanner = new MobileBarcodeScanner();
            ScanCommand = new Command(OnScan);
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }


        private string _code;
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }


        private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(_code);
        }

        public Command ScanCommand { get; }
        public Command CancelCommand { get; }

        public Command SaveCommand { get; }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            var barcode = new Barcode { Code = _code };
            await BarcodeRepository.AddAsync(barcode); 
            await Shell.Current.GoToAsync("..");
        }

        private async void OnScan()
        {
            var result = await _scanner.Scan();
            if (result == null) return;
            _code = result.Text;
        }
    }
}
