using FluentValidation;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public class MarkaValidator:AbstractValidator<Marka>
    {
        public MarkaValidator()
        {
            RuleFor(c => c.MarkaAdi).NotNull().WithMessage("Marka adı boş geçilemez.").Length(1, 50).WithMessage("Marka adı [1-50] karakter aralığında olmalıdır.");
        }
    }
}
