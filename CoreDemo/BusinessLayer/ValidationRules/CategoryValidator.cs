using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Kategori adı girilmesi zorunludur")
                .MaximumLength(100)
                .MinimumLength(3)
                .WithMessage("kategori adı 3-100 karakter aralığında olmalıdır");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Kategori adı boş olamaz")
                .MaximumLength(250)
                .WithMessage("Açıklama 250 karakterden büyük olamaz");

        }
    }
}
