using System;

namespace BarcodeScanner.Models
{
    public class Barcode
    {
        public Barcode()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public string Code { get; set; }
    }
}