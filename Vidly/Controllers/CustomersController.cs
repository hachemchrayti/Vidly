using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>()
            {
                new Customer{ Id=1,Name="Sergio"},
                new Customer{ Id=2,Name="Karim"}

            };
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            if (id == 1)
            {
                return View(new Customer() { Id = 1, Name = "Sergio" });
            }
            else
            {
                return View(new Customer() { Id = 2, Name = "Karim" });
            }

        }
    }
}