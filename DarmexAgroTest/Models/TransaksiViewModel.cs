using System;
using System.Collections.Generic;

namespace DarmexAgroTest.Models
{
    public class TransaksiViewModel
    {
        public Guid TransaksiId { get; set; }
        public string TransaksiDate { get; set; }
        public string CostumerId { get; set; }
        public string CostumerName { get; set; }
        public string TotalPurchase { get; set; }
        public string TotalPayment { get; set; }
        public List<TransaksiDetailViewModel> DataItems { get; set; }
    }
}
