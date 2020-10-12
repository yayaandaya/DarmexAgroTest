using System;
using System.ComponentModel.DataAnnotations;

namespace DarmexAgroTest.Models
{
    public class ProdukDetail
    {
        [Key]
        public Guid ProdukDetailId { get; set; }
        public string ProdukId { get; set; }
        public string ProdukDetailName { get; set; }
        public double PricePerItem { get; set; }
        public decimal Discount { get; set; }
    }
}
