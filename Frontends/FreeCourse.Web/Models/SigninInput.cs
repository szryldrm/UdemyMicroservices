using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.Web.Models
{
    public class SigninInput
    {
        [Required(ErrorMessage = "Lütfen Email Adresini Giriniz...")]
        [Display(Name = "Email Adresiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Parolanızı Giriniz...")]
        [Display(Name = "Şifreniz")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool IsRemember { get; set; }
    }
}
