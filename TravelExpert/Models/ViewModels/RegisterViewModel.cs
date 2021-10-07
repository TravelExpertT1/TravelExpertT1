using System.ComponentModel.DataAnnotations;

namespace TravelExpert.Models
{
    public class RegisterViewModel
    {
        // [Required(ErrorMessage = "Please enter a username.")]
        //  [StringLength(255)]
        
        
        [Required(ErrorMessage = "Please enter an email address.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address.")]
        [StringLength(51, ErrorMessage = "The email address must not be less than 51 characters.")]

        public string Username { get; set; }







        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(255)]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please enter a last name.")]
        [StringLength(255)]
        public string Lastname { get; set; }

        /* [Required(ErrorMessage = "Please enter an email address.")]
          [DataType(DataType.EmailAddress)]
          public string Email { get; set; }
        */
        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}