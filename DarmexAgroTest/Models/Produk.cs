using System;
using System.ComponentModel.DataAnnotations;

namespace DarmexAgroTest.Models
{
    public class Produk
    {
        [Key]
        public Guid ProdukId { get; set; }
        public string ProdukName { get; set; }
    }
}
