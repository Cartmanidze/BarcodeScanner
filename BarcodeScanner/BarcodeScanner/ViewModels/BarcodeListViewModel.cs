using BarcodeScanner.Models;
using BarcodeScanner.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BarcodeScanner.ViewModels
{
    public class BarcodeListViewModel : BaseViewModel
    {

        public ObservableCollection<Barcode> BarcodeList { get; }
        public Command LoadBarcodeListCommand { get; }
        public Command AddBarcodeCommand { get; }
        public Command<Barcode> BarcodeTapped { get; }

        public BarcodeListViewModel()
        {
            Title = "BarcodeList";
            BarcodeList = new ObservableCollection<Barcode>();
            LoadBarcodeListCommand = new Command(async () => await ExecuteLoadItemsCommand());

            BarcodeTapped = new Command<Barcode>(OnBarcodeSelected);

            AddBarcodeCommand = new Command(OnAddBarcode);
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                BarcodeList.Clear();
                var items = await BarcodeRepository.GetAllAsync();
                foreach (var item in items)
                {
                    BarcodeList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBarcode = null;
        }

        private Barcode _selectedBarcode;
        public Barcode SelectedBarcode
        {
            get => _selectedBarcode;
            set
            {
                SetProperty(ref _selectedBarcode, value);
                OnBarcodeSelected(value);
            }
        }

        private async void OnAddBarcode(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewBarcodePage));
        }

        private async void OnBarcodeSelected(Barcode item)
        {
            if (item == null) return;

            await Shell.Current.GoToAsync($"{nameof(BarcodeDetailPage)}?{nameof(BarcodeDetailViewModel.ItemId)}={item.Id}");
        }
    }
}