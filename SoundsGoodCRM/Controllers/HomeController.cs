using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundsGoodCRM.DAO;
using SoundsGoodCRM.DAO.CustomerModels;
using SoundsGoodCRM.DAO.InstrumentModels;
using SoundsGoodCRM.DAO.UserModels;
using SoundsGoodCRM.DTO;
using SoundsGoodCRM.Models;
using System;
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


		[Route("[controller]/[action]")]
		public IActionResult CreateCustomer() => View();

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult CreateCustomer(CustomerDTO customerDTO)
		{
			//Checking if customer already exist in db
			bool customerExists = Context.Customers
				.Any(c => c.FirstName == customerDTO.FirstName && c.LastName == customerDTO.LastName);
			if (customerExists)
			{
				//Error message calling (alert)
				ModelState.AddModelError(string.Empty, "Customer with the same name already exists.");
				return View(customerDTO);
			}
			bool contactsExist = Context.CustomerContacts
				.Any(c => c.PhoneNumber == customerDTO.PhoneNumber || c.Email == customerDTO.Email);
			if (contactsExist)
			{
				ModelState.AddModelError(string.Empty, "Customer with the same phone number or email already exists.");
				return View(customerDTO);
			}
			var newContactId = Context.CustomerContacts.Any() ? Context.CustomerContacts.Max(p => p.Id) + 1 : 1;
			var newCustomerId = Context.Customers.Any() ? Context.Customers.Max(p => p.Id) + 1 : 1;
			CustomerContact contact = new CustomerContact(newContactId, customerDTO.PhoneNumber, customerDTO.Email);
			Customer customer = new Customer(newCustomerId, customerDTO.FirstName, customerDTO.LastName, newContactId);

			Context.CustomerContacts.Add(contact);
			Context.Customers.Add(customer);
			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "Customer was created successfully!";

			return RedirectToAction("ListOfCustomers");
		}



		[Route("[controller]/[action]")]
		public IActionResult ListOfCustomers() => View();


		[Route("[controller]/[action]")]
		public IActionResult CustomerInfo(int id)
		{

			var customer = Context.Customers
			  .Where(c => c.Id == id)
			  .Select(c => new CustomerDTO(
			  c.Id,
			  c.CustomerContactsId,
			  c.FirstName,
			  c.LastName,
			  c.Contact.PhoneNumber,
			  c.Contact.Email))
			  .FirstOrDefault();

			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		[Route("[controller]/[action]")]
		public IActionResult EditCustomer(int id)
		{

			var customer = Context.Customers
			  .Where(c => c.Id == id)
			  .Select(c => new CustomerDTO(
			  c.Id,
			  c.CustomerContactsId,
			  c.FirstName,
			  c.LastName,
			  c.Contact.PhoneNumber,
			  c.Contact.Email))
			  .FirstOrDefault();

			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}
		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult EditCustomer(CustomerDTO customerDTO)
		{
			var dbCustomer = Context.Customers.Find(customerDTO.CustomerId);
			if (dbCustomer == null)
			{
				return NotFound();
			}
			dbCustomer.FirstName = customerDTO.FirstName;
			dbCustomer.LastName = customerDTO.LastName;

			var dbCustomerContact = Context.CustomerContacts.Find(dbCustomer.CustomerContactsId);
			dbCustomerContact.PhoneNumber = customerDTO.PhoneNumber;
			dbCustomerContact.Email = customerDTO.Email;

			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "Customer`s info successfully edited!";

			
			return RedirectToAction("CustomerInfo", new { id = customerDTO.CustomerId });
		}

		[Route("[controller]/[action]")]
		public IActionResult CreateInstrument() => View();

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult CreateInstrument(InstrumentDTO instrumentDTO)
		{
			//Checking if instrument already exist in db
			bool instrumentExists = Context.Instruments
				.Any(i => i.SerialNumber == instrumentDTO.SerialNumber && i.Model.ModelName == instrumentDTO.Model);
			if (instrumentExists)
			{
				//Error message calling (alert)
				ModelState.AddModelError(string.Empty, "Customer with the same name already exists.");
				return View(instrumentDTO);
			}

			var modelId = Context.InstrumentModels.FirstOrDefault(m => m.ModelName == instrumentDTO.Model).Id;
			var tuningId = Context.InstrumentTunings.FirstOrDefault(t => t.Tune == instrumentDTO.Tuning).Id;
			var newInstrumentId = Context.Instruments.Any() ? Context.Instruments.Max(p => p.Id) + 1 : 1;

			Instrument instrument = new(newInstrumentId, modelId, tuningId, instrumentDTO.SerialNumber);


			Context.Instruments.Add(instrument);
			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "Instrument was created successfully!";

			return RedirectToAction("OrdersTable");
		}

		[Route("[controller]/[action]")]
		public IActionResult ListOfInstruments() => View();

		[Route("[controller]/[action]")]
		public IActionResult CreateUser() => View();

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult CreateUser(UserDTO userDTO)
		{
			//Checking if customer already exist in db
			bool customerExists  = Context.Users.Any(u => u.FirstName == userDTO.FirstName && u.LastName == userDTO.LastName);
			
			if (customerExists)
			{
				//Error message calling (alert)
				ModelState.AddModelError(string.Empty, "Customer with the same name already exists.");
				return View(userDTO);
			}
			bool contactsExist = Context.UserContacts
				.Any(u => u.PhoneNumber == userDTO.PhoneNumber || u.Email == userDTO.Email);
			if (contactsExist)
			{
				ModelState.AddModelError(string.Empty, "Customer with the same phone number or email already exists.");
				return View(userDTO);
			}
			var newContactId = Context.UserContacts.Any() ? Context.UserContacts.Max(u => u.Id) + 1 : 1;
			int newUserId = Context.Users.Any() ? Context.Users.Max(u => u.Id) + 1 : 1;
			var newUserAuthId = Context.UsersAuthorization.Any() ? Context.UsersAuthorization.Max(u => u.Id) + 1 : 1;
			var userPermissionId = Context.UserPermissions.FirstOrDefault(p => p.Permission == userDTO.Permission).Id;

			UserAuthorization auth = new (newUserAuthId, userDTO.Login, userDTO.Password);
			UserContact contact = new(newContactId, userDTO.PhoneNumber, userDTO.Email);
			User user = new (newUserId,userDTO.FirstName, userDTO.LastName,newContactId, userPermissionId, newUserAuthId);

			Context.UsersAuthorization.Add(auth);
			Context.UserContacts.Add(contact);
			Context.Users.Add(user);
			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "New user was created successfully!";

			return RedirectToAction("ListOfUsers");
		}

		[Route("[controller]/[action]")]
		public IActionResult UserInfo(int id)
		{

			var user = Context.Users
			  .Where(u => u.Id == id)
			  .Select(u => new UserDTO(
				  u.Id,
				  u.UserContactsId,
				  u.UserAuthorizationId,
				  u.FirstName,
				  u.LastName,
				  u.UserContact.PhoneNumber,
				  u.UserContact.Email,
				  u.UserAuthorization.Login,
				  u.UserAuthorization.Password,
				  u.UserPermission.Permission))
			  .FirstOrDefault();

			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		[Route("[controller]/[action]")]
		public IActionResult ListOfUsers() => View();
	}

}