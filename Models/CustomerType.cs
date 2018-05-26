using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleMVC.Models
{
    public class CustomerType
    {
        public int Id { get; set; }
        public string Type { get; set; }

        //public IEnumerable<CustomerType> GetCustomerTypes()
        //{
        //    List<CustomerType> customerTypes = new List<CustomerType>();
        //    customerTypes.Add(new CustomerType { Id = 1, Type = "BUS" });
        //    customerTypes.Add(new CustomerType { Id = 2, Type = "HS" });
        //    customerTypes.Add(new CustomerType { Id = 3, Type = "GOV" });
        //    customerTypes.Add(new CustomerType { Id = 4, Type = "EDU" });
        //    customerTypes.Add(new CustomerType { Id = 5, Type = "GRK" });
        //    customerTypes.Add(new CustomerType { Id = 6, Type = "OTH" });
        //    return customerTypes;
        //}
    }
}