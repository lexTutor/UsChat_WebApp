using System;
using System.ComponentModel.DataAnnotations;

namespace UsApplication.DTOs
{
    public class ReceiveUserDTO
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Email must be in the required format e.g chibuikemakpakar@gmail.com")]
        public string Email{ get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(14, ErrorMessage = "Phone number must not be more than 14 characters")]
        [RegularExpression(@"^\+\d{3}\d{9,10}$", ErrorMessage = "Must have country-code and must be 13, 14 chars long e.g. +2348050000000")]
        public string PhoneNumber { get; set; }
    }
}
