using System;
using System.ComponentModel.DataAnnotations;

namespace DarmexAgroTest.Models
{
    public class TransaksiDetail
    {
        [Key]
        public Guid TransaksiDetailId { get; set; }
        public string TransaksiId { get; set; }
        public string ProdukDetailId { get; set; }
        public string ProdukDetailName { get; set; }
        public int NumberOfItems { get; set; }
        public double PricePerItem { get; set; }
        public decimal Discount { get; set; }
        public double TotalPrice { get; set; }
    }
}