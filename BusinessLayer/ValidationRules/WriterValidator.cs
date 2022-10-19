using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
  public class WriterValidator : AbstractValidator<Writer>
  {
    public WriterValidator()
    {
      RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adı Soyadı Boş Geçilmez");
      RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
      RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre Boş Geçilemez");
      RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz");
      RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Giriniz");
      RuleFor(x => x.WriterPassword).Equal(x => x.RepeatPassword).When(x => !String.IsNullOrWhiteSpace(x.WriterPassword)).
        WithMessage("Girdiğiniz Şifreler Aynı Değil");
      RuleFor(x => x.WriterPassword).NotEmpty().MinimumLength(8)
    .Matches("[A-Z]").WithMessage("En Az Bir Tane Büyük Harf İçermeli.")
    .Matches("[a-z]").WithMessage("En Az Bir Tane Küçük Harf İçermeli")
    .Matches("[0-9]").WithMessage("En Az Bir Rakam İçermeli");     
    }

  }
}
