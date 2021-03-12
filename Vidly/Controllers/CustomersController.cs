using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
           _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList(); 
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customers = _context.Customers;
            var customer = customers.Include(c=>c.MembershipType).SingleOrDefault(c=>c.Id==id);

            if (customer == null) return HttpNotFound();
            return View(customer);
        }

        public ActionResult New()
        {

            var memebershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes=memebershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewmodel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);
               // TryUpdateModel(customerInDb);
               customerInDb.Name = customer.Name;
               customerInDb.Birthdate = customer.Birthdate;
               customerInDb.MembershipTypeId = customer.MembershipTypeId;
               customerInDb.isSubscribedToNewsLetter = customer.isSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(customer1 => customer1.Id == id);
            if (customer == null) return HttpNotFound();


            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

             return View("CustomerForm", viewModel);


            
        }

    }
}