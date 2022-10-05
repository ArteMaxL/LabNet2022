using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.MVC.UI.Models
{
    public class CategoryView
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(15, ErrorMessage = "Max 15 characters.")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}