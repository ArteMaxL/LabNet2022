using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.MVC.UI.Models
{
    public class ShipperView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(40, ErrorMessage = "Max 40 characters!")]
        public string Name { get; set; }

        [Phone(ErrorMessage = "Enter a valid phone number!")]
        [StringLength(24, ErrorMessage = "Max 24 characters!")]
        public string Phone { get; set; }
    }
}