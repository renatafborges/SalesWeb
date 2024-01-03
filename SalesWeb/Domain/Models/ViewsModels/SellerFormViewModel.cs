using SalesWeb.Domain.Models.Entities;
using System.Collections.Generic;

namespace SalesWeb.Domain.Models.ViewsModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}