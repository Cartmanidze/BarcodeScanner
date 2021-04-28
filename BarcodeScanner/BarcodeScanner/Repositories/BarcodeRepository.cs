using BarcodeScanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BarcodeScanner.Repositories
{
    public class BarcodeRepository : IBarcodeRepository
    {
        private readonly List<Barcode> _barcodeList;

        public BarcodeRepository()
        {
            _barcodeList = new List<Barcode>();
        }

        public Task<bool> AddAsync(Barcode barcode)
        {
            _barcodeList.Add(barcode);

            return Task.FromResult(true);
        }

        public Task<bool> UpdateAsync(Barcode item)
        {
            var oldItem = _barcodeList.FirstOrDefault(b => b.Id == item.Id);
            _barcodeList.Remove(oldItem);
            _barcodeList.Add(item);

            return Task.FromResult(true);
        }

        public Task<bool> DeleteAsync(Barcode barcode)
        {
            var oldItem = _barcodeList.FirstOrDefault(b => b.Id == barcode.Id);
            _barcodeList.Remove(oldItem);
            return Task.FromResult(true);
        }

        public Task<Barcode> GetAsync(Guid id)
        {
            return Task.FromResult(_barcodeList.FirstOrDefault(s => s.Id == id));
        }

        public Task<IEnumerable<Barcode>> GetAllAsync()
        {
            return Task.FromResult(_barcodeList.AsEnumerable());
        }
    }
}