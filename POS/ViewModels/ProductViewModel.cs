using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace POS.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please enter Product's Name.")]
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        [Required(ErrorMessage = "Please enter Product's Price.")]
        public double Price { get; set; }
        [Display(Name = "Quantities")]
        [Required(ErrorMessage = "Please enter Product's Quantities.")]
        public Guid Qty { get; set; }
    }
}