using FluentValidation;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public class HasarKayitValidator:AbstractValidator<HasarKayit>
    {
        public HasarKayitValidator()
        {
            RuleFor(c => c.Tarih).NotNull().WithMessage("Tarih kısmı boş geçilemez.");
            RuleFor(c => c.Masraf).NotNull().WithMessage("Masraf alanı boş geçilemez.");
            RuleFor(c => c.Parca).NotNull().WithMessage("Parça kısmı boş geçilemez.");
            RuleFor(c => c.TasitId).NotNull().WithMessage("Taşıt alanı boş geçilemez.");
        }
    }
}
