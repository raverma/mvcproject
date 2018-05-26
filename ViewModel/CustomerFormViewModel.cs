using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMVC.Models;
namespace SampleMVC.ViewModel
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }
        public IEnumerable<CustomerType> CustomerTypes { get; set; }

        public string Title
        {
            get
            {
                return (Customer !=null && Customer.Id != 0) ? "Edit Customer" : "New Customer";
            }
        }
    }
}