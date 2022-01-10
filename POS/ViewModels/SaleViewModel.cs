using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.ViewModels
{
    public class SaleViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public double Total { get; set; }
    }
}