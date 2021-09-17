using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GestContact.Models
{
    public class RegisterContact
    {
        [Required]
        [Display(Name = "Nom de famille")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }
        [Required]
        public string Telephone { get; set; }
    }
}