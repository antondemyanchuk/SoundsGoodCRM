﻿using System.ComponentModel.DataAnnotations;

namespace SoundsGoodCRM.DTO
{
    public sealed record CustomerDTO
    {
        public int CustomerId { get; set; }
        public int CustomerContactsId { get; set; }

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

        public CustomerDTO() { }

        public CustomerDTO(int id, int contactId, string firstName, string lastName, string phoneNumber, string email) 
        {
            CustomerId = id;
            CustomerContactsId = contactId;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
