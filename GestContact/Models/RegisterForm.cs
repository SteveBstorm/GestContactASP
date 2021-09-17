using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace GestContact.Models
{
    public class RegisterForm
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Adresse E-Mail")]
        public string Email { get; set; }
        
        [Required]
        [Display(Name = "Pseudonyme")]
        public string ScreenName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]

        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Confirmer mot de passe")]

        public string ConfirmPassword { get; set; }

    }
}