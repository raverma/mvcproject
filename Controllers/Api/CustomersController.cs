using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SampleMVC.Models;
using SampleMVC.Migrations;
using AutoMapper;
namespace SampleMVC.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private AppDbContext _context;

        public CustomersController()
        {
            _context = new AppDbContext();
        }
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);
            //Customer customer = new Customer();

            //return customer.GetCustomers("").ToList();
            
        }

        public IHttpActionResult GetCustomer(int id)
        {
            //var customer = new Customer(custId);
            var customer = _context.Customers.Single(c => c.Id == id);
            if (customer == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            }
            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();
            }

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            //return customerDto;
            return Ok(customerDto);
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            var customerInDB = _context.Customers.Single(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(customerDto, customerInDB);
            //customerInDB.Name = customer.Name;
            //customerInDB.Abbreviation = customer.Abbreviation;
            //customerInDB.CustomerTypeId = customer.CustomerTypeId;
            //customerInDB.IsActive = customer.IsActive;
            _context.SaveChanges();

        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var customerInDB = _context.Customers.Single(c => c.Id == id);
            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Customers.Remove(customerInDB);
            _context.SaveChanges();

        }
    }
}
