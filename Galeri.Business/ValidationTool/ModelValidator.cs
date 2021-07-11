using FluentValidation;
using Galeri.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galeri.Business.ValidationTool
{
    public class ModelValidator:AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(c => c.Vites).NotNull().WithMessage("Vites alanı boş geçilemez.").Length(1,20).WithMessage("Vites alanı [1-20] karakter aralığında olmalıdır.");
            RuleFor(c => c.Yil).NotNull().WithMessage("Yıl alanı boş geçilemez.");
            RuleFor(c => c.MotorGucu).NotNull().WithMessage("Motor gücü alanı boş geçilemez.");
            RuleFor(c => c.MotorHacmi).NotNull().WithMessage("Motor hacmi alanı boş geçilemez.");
            RuleFor(c => c.AzamiSurat).NotNull().WithMessage("Azami sürat alanı boş geçilemez.");
            RuleFor(c => c.BagajKapasitesi).NotNull().WithMessage("Bagaj kapasitesi alanı boş geçilemez.");
            RuleFor(c => c.MarkaId).NotNull().WithMessage("Marka alanı boş geçilemez.");
            RuleFor(c => c.KasaTipi).NotNull().WithMessage("Kasa tipi alanı boş geçilemez.").Length(1,25).WithMessage("Kasa tipi alanı [1-25] karakter aralığında olmalıdır.");
            RuleFor(c => c.Cekis).NotNull().WithMessage("Çekiş alanı boş geçilemez.").Length(1,15).WithMessage("Çekiş alanı [1-15] karakter aralığında olmalıdır.");
            RuleFor(c => c.Yakit).NotNull().WithMessage("Yakıt alanı boş geçilemez.").Length(1, 15).WithMessage("Yakıt alanı [1-15] karakter aralığında olmalıdır.");
            RuleFor(c => c.ModelAdi).NotNull().WithMessage("Model adı alanı boş geçilemez.").Length(1, 50).WithMessage("Model adı alanı [1-50] karakter aralığında olmalıdır.");
        }
    }
}
