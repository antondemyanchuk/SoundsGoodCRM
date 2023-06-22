using SoundsGoodCRM.DAO.UserModels;
using System.ComponentModel.DataAnnotations;

namespace SoundsGoodCRM.DTO
{
	public class UserDTO
	{

		public int Id { get; set; }
		public int UserContactsId { get; set; }
		public int UserAuthorizationId { get; set; }

		[Required(ErrorMessage = "First Name is required.")]
		[MinLength(3, ErrorMessage = "First Name must be at least 3 characters long.")]
		[StringLength(100, ErrorMessage = "First Name cannot be longer than 100 characters.")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is required.")]
		[StringLength(100, ErrorMessage = "Last Name cannot be longer than 100 characters.")]
		public string LastName { get; set; }

		[Required(ErrorMessage = "Phone number is required.")]
		[RegularExpression("^(?:\\+|\\d{1,3})\\s?(?:\\(\\d{1,3}\\))?(?:[-.\\s]?\\d{1,}){7,}\\b",
			ErrorMessage = "Please, type correct phone number")]
		public string PhoneNumber { get; set; }


		[Required(ErrorMessage = "Email is required.")]
		[RegularExpression("^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}$",
			ErrorMessage = "Please, type correct email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Login is required.")]
		public string Login { get; set; }
		//[Required(ErrorMessage = "Password is required.")]
		//[MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
		//[RegularExpression("^(?=.*[A-Z])(?=.*[\\p{P}\\p{S}]).+$",
		//	ErrorMessage = "At least one uppercase letter and one spec symbol required ")]
		public string Password { get; set; }

		//[Required(ErrorMessage = "Password is required.")]
		//[MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
		//[RegularExpression("(?=.*[A-Z])(?=.*[\\p{P}\\p{S}]).+",
		//	ErrorMessage = "At least one uppercase letter and one spec symbol required ")]
		public string ConfirmPassword { get; set; }

		[Required(ErrorMessage = "Permission is required.")]

		public string Permission { get; set; }

		public UserDTO() { }
		public UserDTO(int id, string firstName, string lastName, string phoneNumber, string email, string permission)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			Email = email;
			Permission = permission;
		}
		public UserDTO(int id, string firstName, string lastName, string phoneNumber, string email, string login, string password, string permission)
		{
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			Email = email;
			Login = login;
			Password = password;

		}
		public UserDTO(int id, int userContactId, int userAuthId, string firstName, string lastName, string phoneNumber, string email, string login, string password, string permission)
		{
			Id = id;
			UserContactsId = userContactId;
			UserAuthorizationId = userAuthId;
			FirstName = firstName;
			LastName = lastName;
			PhoneNumber = phoneNumber;
			Email = email;
			Login = login;
			Password = password;

		}
	}
}

