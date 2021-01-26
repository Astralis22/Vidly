using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

        public IEnumerable<Discount> Rates { get; set; }

        public CustomerFormViewModel()
        {
            Rates = new List<Discount>
            {
                new Discount(0),
                new Discount(1),
                new Discount(2),
                new Discount(3),
                new Discount(4),
                new Discount(5)
            };
        }
    }
}