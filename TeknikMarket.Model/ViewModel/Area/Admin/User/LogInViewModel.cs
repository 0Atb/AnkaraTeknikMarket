using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeknikMarket.Model.ViewModel.Area.Admin.User
{
    public class LogInViewModel
    {
        //data annotations

        //[EmailAddress(ErrorMessage = "Lütfen Geçerli Email Giriniz.")]
        //[Required(ErrorMessage = "Lütfen Email Giriniz")]
        public string Email { get; set; }
        //[Required(ErrorMessage ="Lütfen Şifre Giriniz.")]
        //[MinLength(3,ErrorMessage ="Lütfen 3 karakterden fazla giriniz")]
        //[MaxLength(15,ErrorMessage ="Lütfen 15 karakterden fazla giriniz")]
        public string Sifre { get; set; }

        public bool BeniHatirla { get; set; }
    }
}
