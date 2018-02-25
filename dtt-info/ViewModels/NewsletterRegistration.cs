using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DttInfo.ViewModels
{
    public class NewsletterRegistration
    {
        [Required(ErrorMessage = "Please enter your first name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", 
            ErrorMessage = "Please enter correct email address")]
        public string Email { get; set; }
    }
}