using FluentValidation;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public class YorumValidator:AbstractValidator<Yorum>
    {
        public YorumValidator()
        {
            this.RuleFor(c => c.Ad).Length(1, 25).WithMessage("Ad alanı [1-25] karakter aralığında olmalıdır.").NotNull().WithMessage("Ad alanı boş geçilemez.");
            this.RuleFor(c => c.Soyad).Length(1, 25).WithMessage("Soyad alanı [1-25] karakter aralığında olmalıdır.").NotNull().WithMessage("Soyad alanı boş geçilemez.");
            this.RuleFor(c => c.Mail).Length(1,100).WithMessage("Mail alanı [1-100] karakter aralığında olmalıdır.").NotNull().WithMessage("Mail alanı boş geçilemez.");
            this.RuleFor(c => c.Icerik).Length(1, 2500).WithMessage("İçerik alanı [1-2500] karakter aralığında olmalıdır.").NotNull().WithMessage("İçerik alanı boş geçilemez.");
            this.RuleFor(c => c.TasitId).NotNull().WithMessage("Yorumun ait olduğu taşıt girilmelidir.(Sistemsel Hata!)");
        }
    }
}
