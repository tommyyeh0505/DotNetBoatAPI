using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace A1backend.ViewFolders
{
    public class ApplicationUser : IdentityUser
    {

        //public class RegistrationViewModel { 
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        override
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        override
        public string PhoneNumber { get; set; }
    }

}
