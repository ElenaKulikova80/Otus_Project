using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Identity.WebAPI.Models;
public class ApplicationUserAuthenticationModel
{
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

  
}

