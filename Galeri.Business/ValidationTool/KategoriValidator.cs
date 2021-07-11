using FluentValidation;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public class KategoriValidator:AbstractValidator<Kategori>
    {
        public KategoriValidator()
        {
            RuleFor(c => c.KategoriAdi).NotNull().WithMessage("Kategori adı boş geçilemez.").Length(1, 50).WithMessage("Kategori adı [1-50] karakter aralığında olmalıdır.");
        }
    }
}
