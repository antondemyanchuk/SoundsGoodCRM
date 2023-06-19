using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundsGoodCRM.DAO;
using SoundsGoodCRM.DAO.CustomerModels;
using SoundsGoodCRM.DTO;
using SoundsGoodCRM.Models;
using SoundsGoodCRM.DTO;
using System.Diagnostics;

namespace SoundsGoodCRM.Controllers
{
    public class HomeController : Controller
    {
        public readonly SampleContext Context;


        public HomeController(SampleContext context)
        {
            Context = context;
        }

        public IActionResult Index() => View();

        public IActionResult OrdersTable() => View();


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CreateCustomer() => View();

        [HttpPost]
        public IActionResult CreatePerson(CreateCustomerDTO customerDTO)
        {
            var newContactId = Context.CustomerContacts.Max(p => p.Id) + 1;
            var newCustomerId = Context.Customers.Max(p => p.Id) + 1;
            CustomerContact contact = new (newContactId, customerDTO.PhoneNumber, customerDTO.Email);
            Customer customer = new(newCustomerId, customerDTO.FirstName, customerDTO.LastName, newCustomerId);

            Context.CustomerContacts.Add(contact);
            Context.Customers.Add(customer);
            Context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}