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
                new Discount(10),
                new Discount(20),
                new Discount(30),
                new Discount(40),
                new Discount(50)
            };
        }
    }
}