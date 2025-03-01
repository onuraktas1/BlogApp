using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .WithMessage("İsim boş geçilemez")
                .MinimumLength(2)
                .MaximumLength(50)
                .WithMessage("İsim, soyisim 2-50 karakter arasında olmak zorundadır");


            RuleFor(x => x.Mail)
                .NotEmpty()
                .NotNull()
                .WithMessage("Mail alanı boş geçilemez")
                .EmailAddress()
                .WithMessage("Mail adresini doğru formatta giriniz");


            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("Şifre boş geçilemez")
                .MinimumLength(6)
                .MaximumLength(16)
                .WithMessage("Şifre 6-16 karakter arasında olması gerekiyor")
                .Matches(@"[A-Z]+")
                .WithMessage("Şifrenizde en az bir büyük karakter olması gerekiyor")
                .Matches(@"[a-z]+")
                .WithMessage("Şifrenizde en az bir küçük karakter olması gerekiyor")
                .Matches(@"[0-9]+")
                .WithMessage("Şifrenizde en az bir rakam bulunması gerekiyor");
        }
    }
}
