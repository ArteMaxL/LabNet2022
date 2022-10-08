using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.API.Models
{
    public class CategoryView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required!")]
        [StringLength(15, ErrorMessage = "Max 15 characters!")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Max 255 characters!")]
        public string Description { get; set; }
    }
}