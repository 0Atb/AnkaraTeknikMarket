using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.Model.ViewModel.Area.Admin.User;

namespace TeknikMarket.Business.ValidationRule.Areas.Admin
{
    public class LoginVmValidator:AbstractValidator<LogInViewModel>
    {

        public LoginVmValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Email Alanını Boş Bırakmayınız").NotNull().WithMessage("Lütfen Email Formatında Giriniz").EmailAddress().WithMessage("Lütfen Email Formatında Giriniz").Equal(x=>x.Email).WithMessage("Email Eşleşmiyor.");

            RuleFor(x => x.Sifre).NotEmpty().WithMessage("Lütfen Şifre Alanını Boş Bırakmayınız").NotNull().WithMessage("Şifre Alanı Zorunlu").MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.").MaximumLength(15).WithMessage("Lütfen en fazla 15 karakter giriniz").Equal(x => x.Sifre).WithMessage("Şifre Eşleşmiyor.");
        }

    }
}
