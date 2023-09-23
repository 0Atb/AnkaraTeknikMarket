using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.Model.ViewModel.Area.Admin.User;

namespace TeknikMarket.Business.ValidationRule.Areas.Admin
{
    public class ForgotPasswordVmValidator:AbstractValidator<ForgotPasswordViewModel>
    {
        public ForgotPasswordVmValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Lütfen Email Alanını Boş Bırakmayınız").EmailAddress().WithMessage("Lütfen Email Formatı Giriniz.");
            RuleFor(x => x.Adi).NotEmpty().WithMessage("Adınız Alanını Boş Bırakmayınız.");
            RuleFor(x => x.Soyadi).NotEmpty().WithMessage("Soyadınız Alanını Boş Bırakmayınız.");
        }
    }
}
