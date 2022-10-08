using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.API.Models
{
    public class CustomerView
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(40, ErrorMessage = "Max 40 characters!")]       
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Contact Name is Required!")]
        [StringLength(30, ErrorMessage = "Max 30 characters!")]
        public string ContactName { get; set; }

        [StringLength(30, ErrorMessage = "Max 30 characters!")]
        public string ContactTitle { get; set; }

        [Required(ErrorMessage = "City is Required!")]
        [StringLength(15, ErrorMessage = "Max 15 characters!")]
        public string City { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number!")]
        [StringLength(24, ErrorMessage = "Max 24 characters!")]
        public string Phone { get; set; }

    }
}