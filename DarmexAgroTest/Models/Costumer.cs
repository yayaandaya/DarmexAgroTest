using System;
using System.ComponentModel.DataAnnotations;

namespace DarmexAgroTest.Models
{
    public partial class Costumer
    {
        [Key]
        public Guid CostumerId { get; set; }
        public string CostumerName { get; set; }
        public string Address { get; set; }
    }
}
