using DAL;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SampleMVC.Models
{
    public class Customer
	{
		public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        
       
        public CustomerType CustomerType { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }

        public string Abbreviation { get; set; }

        public bool IsActive { get; set; }

        //public Customer(int customerId)
        //{
        //     GetCustomer(customerId);
        //}
        //public void GetCustomer(int customerId)
        //{
            //string sql = "Select CustId, CustomerName, Type, Abbrev, Active from Customers where CustId=" + customerId;
            //DBAccess dBAccess = new DBAccess();
            //DataTable dt = dBAccess.GetData(sql);
            //if (dt !=null && dt.Rows.Count > 0)
            //{
            //    this.Id = System.Convert.ToInt32(dt.Rows[0]["CustId"]);
            //    this.Name = dt.Rows[0]["CustomerName"].ToString();
            //    this.CustomerType = dt.Rows[0]["Type"].ToString();
            //    this.Abbreviation = dt.Rows[0]["Abbrev"].ToString();
            //    this.IsActive = System.Convert.ToBoolean(dt.Rows[0]["Active"]);
            //}
            //var customers = GetCustomers(string.Format("custid={0}", customerId));
            //return customers.FirstOrDefault();
        //}

        //public void SaveCustomer()
        //{
        //    DBAccess dBAccess = new DBAccess();
        //    string error = string.Empty;
        //    string sql = "Insert into Customers values ('" + Name + "','" + CustomerType + "','" + Abbreviation + "'," + System.Convert.ToSingle(IsActive) + ")";
        //    dBAccess.ExecuteSQL(sql, out error);
        //}

        //public List<Customer> GetCustomers(string filter)
        //{
        //    DBAccess dbAccess = new DBAccess();
        //    string error = string.Empty;
        //    DataTable dt;
        //    List<Customer> customers = new List<Customer>();
        //    StringBuilder sql = new StringBuilder("Select * from Customers");
        //    if (filter != string.Empty)
        //    {
        //        sql.Append("where ").Append(filter);
        //    }
        //    dt = dbAccess.GetData(sql.ToString());
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            Customer cust = new Customer
        //            {
        //                Id = System.Convert.ToInt32(row["CustId"]),
        //                Name = row["CustomerName"].ToString(),
        //                CustomerType = row["Type"].ToString(),
        //                Abbreviation = row["Abbrev"].ToString(),
        //                IsActive = System.Convert.ToBoolean(row["Active"])
        //            };
        //            customers.Add(cust);
        //        }
        //    }
        //    return customers;
        //}


    }

    public class CustomerDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }


        public CustomerType CustomerType { get; set; }
        [Required]
        [Display(Name = "Customer Type")]
        public int CustomerTypeId { get; set; }

        public string Abbreviation { get; set; }

        public bool IsActive { get; set; }
    }
}