using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace BarcodeScanner.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class BarcodeDetailViewModel : BaseViewModel
    {
        
        public string Id { get; set; }

        private string _code;
        public string Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }


        private string _itemId;
        public string ItemId
        {
            get => _itemId;
            set
            {
                _itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string itemId)
        {
            try
            {
                var item = await BarcodeRepository.GetAsync(Guid.Parse(itemId));
                Id = item.Id.ToString();
                Code = item.Code;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
