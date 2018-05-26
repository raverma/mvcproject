using System.Collections.Generic;
using System.Web.Mvc;
using SampleMVC.Models;
using SampleMVC.ViewModel;
using System.Linq;
using System.Data.Entity;
namespace SampleMVC.Controllers
{
    public class CustomersController : Controller
    {
        private AppDbContext _context;

        public CustomersController()
        {
            _context = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        //[Authorize]
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.CustomerType).ToList();
            return View(customers);
        }

        public ActionResult New()
        {
            var CustomerTypes = _context.CustomerTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                CustomerTypes = CustomerTypes
            };
            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int customerId)
        {
            var customer = _context.Customers.Include(c => c.CustomerType ).SingleOrDefault(c => c.Id == customerId);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                CustomerTypes = _context.CustomerTypes.ToList()
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    CustomerTypes = _context.CustomerTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.CustomerTypeId = customer.CustomerTypeId;
                customerInDb.Abbreviation = customer.Abbreviation;
                customerInDb.IsActive = customer.IsActive;
            }
            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.CustomerType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                CustomerTypes = _context.CustomerTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

       
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
    }
}