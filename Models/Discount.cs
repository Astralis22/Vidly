using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Discount
    {
        public int Rate { get; set; }
        public string Percentage { get; set; }

        public Discount(int rate)
        {
            this.Rate = rate;
            Percentage = Rate.ToString() + "%";
        }
    }
}