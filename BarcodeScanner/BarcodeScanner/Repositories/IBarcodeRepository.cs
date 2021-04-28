using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BarcodeScanner.Models;

namespace BarcodeScanner.Repositories
{
    public interface IBarcodeRepository
    {
        Task<bool> AddAsync(Barcode barcode);
        Task<bool> UpdateAsync(Barcode barcode);
        Task<bool> DeleteAsync(Barcode barcode);
        Task<Barcode> GetAsync(Guid id);
        Task<IEnumerable<Barcode>> GetAllAsync();
    }
}
