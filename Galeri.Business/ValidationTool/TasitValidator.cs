using FluentValidation;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public class TasitValidator:AbstractValidator<Tasit>
    {
        public TasitValidator()
        {
            RuleFor(c => c.Fiyat).NotNull().WithMessage("Fiyat alanı boş geçilemez.");
            RuleFor(c => c.Garanti).NotNull().WithMessage("Garanti alanı boş geçilemez.");
            RuleFor(c => c.Takas).NotNull().WithMessage("Takas alanı boş geçilemez.");
            RuleFor(c => c.Durum).NotNull().WithMessage("Durum alanı boş geçilemez.").Length(1,15).WithMessage("Durum alanı [1-15] karakter aralığında olmalıdır.");
            RuleFor(c => c.Renk).NotNull().WithMessage("Renk alanı boş geçilemez.").Length(1, 50).WithMessage("Renk alanı [1-50] karakter aralığında olmalıdır.");
            RuleFor(c => c.Plaka).NotNull().WithMessage("Plaka alanı boş geçilemez.").Length(1, 7).WithMessage("Plaka alanı [1-7] karakter aralığında olmalıdır.");
            RuleFor(c => c.Aciklama).Length(1, 15000).WithMessage("Açıklama alanı [1-15000] karakter aralığında olmalıdır.");
            RuleFor(c => c.ModelId).NotNull().WithMessage("Model alanı boş geçilemez.");
            RuleFor(c => c.KategoriId).NotNull().WithMessage("Kategori alanı boş geçilemez.");
            RuleFor(c => c.TasitBaslik).NotNull().WithMessage("Taşıt başlığı alanı girilmelidir.").Length(1, 250).WithMessage("Taşıt başlığı alanı [1-250] karakter aralığında olmalıdır.");
            RuleFor(c => c.Kilometre).NotNull().WithMessage("Kilometre bilgisi girilmelidir.");
        }
    }
}
