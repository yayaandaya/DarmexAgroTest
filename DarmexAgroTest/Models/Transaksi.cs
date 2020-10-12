using System;
using System.ComponentModel.DataAnnotations;

namespace DarmexAgroTest.Models
{
    public class Transaksi
    {
        [Key]
        public Guid TransaksiId { get; set; }
        public string TransaksiDate { get; set; }
        public string CostumerId { get; set; }
        public string CostumerName { get; set; }
        public double TotalPurchase { get; set; }
        public double TotalPayment { get; set; }
    }
}
