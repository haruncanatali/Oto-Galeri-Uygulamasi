using FluentValidation;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public class FotografValidator:AbstractValidator<Fotograf>
    {
        public FotografValidator()
        {
            RuleFor(c => c.FotografAdi).NotNull().WithMessage("Fotograf adı boş geçilemez.");
            RuleFor(c => c.TasitId).NotNull().WithMessage("Fotoğrafın ait olduğu taşıt alanı(plaka) boş geçilemez.");
        }
    }
}
