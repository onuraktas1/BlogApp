using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Blog başlığı girilmesi zorunludur")
                .MaximumLength(100)
                .MinimumLength(5)
                .WithMessage("Blog başlığı 5-100 karakter aralığında olmalıdır");

            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Blog içeriği boş olamaz");

            RuleFor(x => x.Image)
                .NotEmpty()
                .WithMessage("Blog görseli boş olamaz");
        }
    }
}
