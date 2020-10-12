using System;
using System.ComponentModel.DataAnnotations;

namespace DarmexAgroTest.Models
{
    public partial class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
