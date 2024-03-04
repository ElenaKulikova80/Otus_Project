using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Identity.WebAPI.Models;

[DataContract]
public class ApplicationUserRegisterModel
{
    [DataMember(Name = "username"), Required]
    public string UserName { get; set; }

    [DataMember(Name = "email"), Required]
    public string Email { get; set; }

    [DataMember(Name = "password"), Required]
    public string Password { get; set; }
}
