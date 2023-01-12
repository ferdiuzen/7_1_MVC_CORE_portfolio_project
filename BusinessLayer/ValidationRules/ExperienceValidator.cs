using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ExperienceValidator:AbstractValidator<Experience>
    {
        public ExperienceValidator()
        {
            //Rulefor metodu ile form içerisinde değer girişinde yetki ve kontrol tanımlamaları yaparız

            RuleFor(x => x.Name).NotEmpty().WithMessage("Deneyim Adı Boş Geçilemez");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Deneyim Açıklaması Boş Geçilemez");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Dönem Alanı Boş Geçilemez");
            
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("En az 4 karakter girmelisiniz");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("En fazla 20 karakter girmelisiniz");

        }

     
    }
}
