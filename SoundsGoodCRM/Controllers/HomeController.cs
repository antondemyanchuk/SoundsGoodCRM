using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundsGoodCRM.DAO;
using SoundsGoodCRM.DAO.CustomerModels;
using SoundsGoodCRM.DAO.InstrumentModels;
using SoundsGoodCRM.DAO.OrderModels;
using SoundsGoodCRM.DAO.UserModels;
using SoundsGoodCRM.DTO;
using SoundsGoodCRM.Models;

using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using System.Data;

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

		public IActionResult ListOfOrders() => View();

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		[Route("[controller]/[action]")]
		[Authorize(Roles = "Admin, Owner")]
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

		[Authorize(Roles = "Admin, Owner")]
		[Route("[controller]/[action]")]
		public IActionResult ListOfCustomers() => View();

		[Authorize(Roles = "Admin, Owner")]
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
		[Authorize(Roles = "Admin, Owner")]
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
		[Authorize(Roles = "Owner")]
		public IActionResult CreateUser() => View();

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult CreateUser(UserDTO userDTO)
		{
			//Checking if customer already exist in db
			bool customerExists = Context.Users.Any(u => u.FirstName == userDTO.FirstName && u.LastName == userDTO.LastName);

			if (customerExists)
			{
				//Error message calling (alert)
				ModelState.AddModelError(string.Empty, "User with the same name already exists.");
				return View(userDTO);
			}
			bool contactsExist = Context.UserContacts
				.Any(u => u.PhoneNumber == userDTO.PhoneNumber || u.Email == userDTO.Email);
			if (contactsExist)
			{
				ModelState.AddModelError(string.Empty, "User with the same phone number or email already exists.");
				return View(userDTO);
			}
			bool LoginExists = Context.UsersAuthorization.Any(u => u.Login == userDTO.Login);
			if (LoginExists)
			{
				ModelState.AddModelError(string.Empty, "User with the same login already exists.");
				return View(userDTO);
			}
			var newContactId = Context.UserContacts.Any() ? Context.UserContacts.Max(u => u.Id) + 1 : 1;
			int newUserId = Context.Users.Any() ? Context.Users.Max(u => u.Id) + 1 : 1;
			var newUserAuthId = Context.UsersAuthorization.Any() ? Context.UsersAuthorization.Max(u => u.Id) + 1 : 1;
			var userPermissionId = Context.UserPermissions.FirstOrDefault(p => p.Permission == userDTO.Permission).Id;

			UserAuthorization auth = new(newUserAuthId, userDTO.Login, PasswordEncryption.HashPassword(userDTO.Password));
			UserContact contact = new(newContactId, userDTO.PhoneNumber, userDTO.Email);
			User user = new(newUserId, userDTO.FirstName, userDTO.LastName, newContactId, userPermissionId, newUserAuthId);

			Context.UsersAuthorization.Add(auth);
			Context.UserContacts.Add(contact);
			Context.Users.Add(user);
			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "New user was created successfully!";

			return RedirectToAction("ListOfUsers");
		}

		[Route("[controller]/[action]")]
		[Authorize(Roles = "Owner")]
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
		[Authorize(Roles = "Owner")]
		public IActionResult EditUser(int id)
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

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult EditUser(UserDTO userDTO)
		{
			var dbUser = Context.Users.Find(userDTO.Id);
			if (dbUser == null)
			{
				return NotFound();
			}
			dbUser.FirstName = userDTO.FirstName;
			dbUser.LastName = userDTO.LastName;
			dbUser.UserPermissionsId = Context.UserPermissions
				.FirstOrDefault(u => u.Permission == userDTO.Permission).Id;

			var dbUserAuth = Context.UsersAuthorization.Find(userDTO.UserAuthorizationId);
			dbUserAuth.Login = userDTO.Login;
			dbUserAuth.Password = PasswordEncryption.HashPassword(userDTO.Password);

			var dbUserContact = Context.UserContacts.Find(userDTO.UserContactsId);
			dbUserContact.PhoneNumber = userDTO.PhoneNumber;
			dbUserContact.Email = userDTO.Email;

			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "Users`s info successfully edited!";

			return RedirectToAction("UserInfo", new { id = userDTO.Id });
		}

		[Authorize(Roles = "Owner")]
		[Route("[controller]/[action]")]
		public IActionResult ListOfUsers() => View();

		[Route("[controller]/[action]")]
		[Authorize(Roles = "Admin, Owner")]
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

			var customerFullName = instrumentDTO.CustomerFullName.Split(' ');
			var customerFirstName = customerFullName[0];
			var customerLastName = customerFullName[1];
			var customerId = Context.Customers.FirstOrDefault(c => c.FirstName == customerFirstName && c.LastName == customerLastName).Id;

			var newInstrumentId = Context.Instruments.Any() ? Context.Instruments.Max(p => p.Id) + 1 : 1;

			Instrument instrument = new(newInstrumentId, customerId, modelId, tuningId, instrumentDTO.SerialNumber);

			Context.Instruments.Add(instrument);
			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "Instrument was created successfully!";

			return RedirectToAction("ListOfInstruments");
		}

		[Route("[controller]/[action]")]
		[Authorize(Roles = "Admin, Owner")]
		public IActionResult ListOfInstruments() => View();

		[Route("[controller]/[action]")]
		[Authorize(Roles = "Admin, Owner")]
		public IActionResult InstrumentInfo(int id)
		{
			var instrument = Context.Instruments
			  .Where(i => i.Id == id)
			  .Select(i => new InstrumentDTO(
						i.Id,
						i.Customer.Id,
						i.Model.Type.Id,
						i.Model.Id,
						i.Tuning.Id,
						i.Model.Brand.Id,
						i.SerialNumber,
						i.Model.ModelName,
						i.Customer.FirstName,
						i.Customer.LastName,
						i.Tuning.Tune,
						i.Model.Type.Type,
						i.Model.Brand.BrandName))
			  .FirstOrDefault();

			if (instrument == null)
			{
				return NotFound();
			}

			return View(instrument);
		}
		[Route("[controller]/[action]")]
		[Authorize(Roles = "Admin, Owner")]
		public IActionResult EditInstrument(int id)
		{
			var instrument = Context.Instruments
			  .Where(i => i.Id == id)
			  .Select(i => new InstrumentDTO(
						i.Id,
						i.Customer.Id,
						i.Model.Type.Id,
						i.Model.Id,
						i.Tuning.Id,
						i.Model.Brand.Id,
						i.SerialNumber,
						i.Model.ModelName,
						i.Customer.FirstName,
						i.Customer.LastName,
						i.Tuning.Tune,
						i.Model.Type.Type,
						i.Model.Brand.BrandName))
			  .FirstOrDefault();

			if (instrument == null)
			{
				return NotFound();
			}

			return View(instrument);
		}

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult EditInstrument(InstrumentDTO instrumentDTO)
		{
			var dbInstrument = Context.Instruments.Find(instrumentDTO.Id);
			if (dbInstrument == null)
			{
				return NotFound();
			}
			dbInstrument.SerialNumber = instrumentDTO.SerialNumber;
			dbInstrument.ModelId = instrumentDTO.ModelId;
			var customerFullName = instrumentDTO.CustomerFullName.Split(' ');
			var customerFirstName = customerFullName[0];
			var customerLastName = customerFullName[1];
			dbInstrument.CustomerId = Context.Customers.FirstOrDefault(c => c.FirstName == customerFirstName && c.LastName == customerLastName).Id;
			dbInstrument.TuneId = Context.InstrumentTunings.FirstOrDefault(t => t.Tune == instrumentDTO.Tuning).Id;

			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "Users`s info successfully edited!";

			return RedirectToAction("InstrumentInfo", new { id = instrumentDTO.Id });
		}

		[Route("[controller]/[action]")]
		public IActionResult CreateOrder() => View();

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult CreateOrder(OrderDto orderDto)
		{
			var newOrderId = Context.Orders.Any() ? Context.Orders.Max(u => u.Id) + 1 : 1;

			var customerFullName = orderDto.CustomerName.Split(' ');
			var customerFirstName = customerFullName[0];
			var customerLastName = customerFullName[1];
			//Checking if customer already exist in db
			bool customerExists = Context.Customers
				.Any(c => c.FirstName == customerFirstName && c.LastName == customerLastName);
			if (!customerExists)
			{
				//Error message calling (alert)
				ModelState.AddModelError(string.Empty, "No customer found. Add new customer first");
				return View(orderDto);
			}
			var customerId = Context.Customers.FirstOrDefault(c => c.FirstName == customerFirstName && c.LastName == customerLastName).Id;
			
			//Checking if instrument already exist in db
			bool instrumentExists = Context.Instruments
				.Any(i => i.SerialNumber == orderDto.SerialNumber );
			if (!instrumentExists)
			{
				//Error message calling (alert)
				ModelState.AddModelError(string.Empty, "No instrument found. Create instrument first");
				return View(orderDto);
			}

			var instrumentId = Context.Instruments.FirstOrDefault(i => i.SerialNumber == orderDto.SerialNumber).Id;

			Order order = new(newOrderId, customerId, instrumentId, orderDto.Description);

			Context.Orders.Add(order);
			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "New order was created successfully!";

			return RedirectToAction("ListOfOrders");
		}

		[Route("[controller]/[action]")]
		public IActionResult ListOfOrder() => View();

		[Route("[controller]/[action]")]
		public IActionResult OrderInfo(int id)
		{
			var instrument = Context.Orders
			  .Where(o => o.Id == id)
			  .Select(o => new OrderDto(
							o.Id,
							o.Customer.Id,
							o.Instrument.Id,
							o.Instrument.SerialNumber,
							o.Instrument.Model.Type.Type,
							o.Instrument.Model.Brand.BrandName,
							o.Instrument.Model.ModelName,
							o.Instrument.Tuning.Tune,
							$"{o.Customer.FirstName} {o.Customer.LastName}",
							o.Customer.Contact.PhoneNumber,
							o.Description))
			  .FirstOrDefault();

			if (instrument == null)
			{
				return NotFound();
			}

			return View(instrument);
		}

		[Route("[controller]/[action]")]
		public IActionResult EditOrder(int id)
		{
			var instrument = Context.Orders
			  .Where(o => o.Id == id)
			  .Select(o => new OrderDto(
							o.Id,
							o.Customer.Id,
							o.Instrument.Id,
							o.Instrument.SerialNumber,
							o.Instrument.Model.Type.Type,
							o.Instrument.Model.Brand.BrandName,
							o.Instrument.Model.ModelName,
							o.Instrument.Tuning.Tune,
							$"{o.Customer.FirstName} {o.Customer.LastName}",
							o.Customer.Contact.PhoneNumber,
							o.Description))
			  .FirstOrDefault();

			if (instrument == null)
			{
				return NotFound();
			}

			return View(instrument);
		}

		[HttpPost]
		[Route("[controller]/[action]")]
		public IActionResult EditOrder(OrderDto orderDto)
		{
			var dbOrder = Context.Orders.FirstOrDefault( o => o.Id == orderDto.Id);
			if (dbOrder == null)
			{
				return NotFound();
			}

			var customerFullName = orderDto.CustomerName.Split(' ');
			var customerFirstName = customerFullName[0];
			var customerLastName = customerFullName[1];
			var customerId = Context.Customers.FirstOrDefault(c => c.FirstName == customerFirstName && c.LastName == customerLastName).Id;
			dbOrder.CustomerId = customerId;

			var instrumentId = Context.Instruments.FirstOrDefault(i => i.SerialNumber == orderDto.SerialNumber).Id;
			dbOrder.InstrumentId = instrumentId;
			
			dbOrder.Description = orderDto.Description;
			
			Context.SaveChanges();

			//Toasts notifications
			TempData["ToastMessage"] = "Users`s info successfully edited!";

			return RedirectToAction("OrderInfo", new { id = orderDto.Id });
		}
		public IActionResult Login() => View();

		[HttpPost]
		public async Task<IActionResult> Login(UserAuthDTO uaDto)
		{
			var hashPass = PasswordEncryption.HashPassword(uaDto.Password);
			//Get auth data
			var dbUserAuthData = await Context.UsersAuthorization.FirstOrDefaultAsync(a =>
				a.Login == uaDto.Login && a.Password == hashPass);
			if (dbUserAuthData == null) return RedirectToAction("Login");

			//Get user data
			var dbUser = await Context.Users.FirstOrDefaultAsync(u => u.UserAuthorizationId == dbUserAuthData.Id);

			//Get user permission
			var dbUserPermission = await Context.UserPermissions.FirstOrDefaultAsync(p => p.Id == dbUser.UserPermissionsId);

			await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(new ClaimsIdentity(
					new List<Claim>
					{
					new(ClaimTypes.Name, dbUserAuthData.Login),
					new(ClaimTypes.Role, dbUserPermission.Permission)
					}, CookieAuthenticationDefaults.AuthenticationScheme)));

			if (!string.IsNullOrWhiteSpace(uaDto.ReturnUrl) && Url.IsLocalUrl(uaDto.ReturnUrl))
				return Redirect(uaDto.ReturnUrl);
			return RedirectToAction("ListOfOrders");
		}
		public async Task<IActionResult> Logout()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Login");
		}
	}

} 