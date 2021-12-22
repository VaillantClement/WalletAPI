using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalletAPI.Domain.Attributes;

namespace WalletAPI.Domain.Models
{
    public class Identity
    {
        [Required]
        [RegularExpression(@"^0[0-9]{6}[M|G|A|P|L|H|B|Z]$", ErrorMessage = "ID card number must follow Malta TIN format.")]
        [Display(Name = "ID Card Number")]
        public string IdCardNumber { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Maximum 20 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Maximum 20 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DateOfBirthIsLegal]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Maximum 30 characters")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$", ErrorMessage = "Password must have more than 8 characters, less than 50, alpha, uppercase alpha, numeric and symbol.")]
        public string Password { get; set; }

        public List<Wallet> Wallets { get; set; } = new List<Wallet>();
    }
}
