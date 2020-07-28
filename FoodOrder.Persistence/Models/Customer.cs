using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FoodOrder.Persistence.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string AddressLine { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
