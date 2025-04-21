using Microsoft.Build.Framework;
// using System.ComponentModel.DataAnnotations;
namespace CoreDemo.Models;

public class UserSignInViewModel
{
    
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
    public string UserName { get; set; }
    
    [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifre Giriniz")]
    public string Password { get; set; }
}