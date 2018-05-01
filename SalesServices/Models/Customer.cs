using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesServices.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }

        public Customer()
        {

        }

        public Customer(SalesServices.Customer data)
        {
            CustomerID = data.CustomerID;
            FirstName = data.FirstName;
            LastName = data.LastName;
            MiddleInitial = data.MiddleInitial;
        }
    }
}