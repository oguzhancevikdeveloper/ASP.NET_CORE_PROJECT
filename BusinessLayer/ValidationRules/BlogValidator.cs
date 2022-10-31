using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
  public class BlogValidator : AbstractValidator<Blog>
  {
    public BlogValidator()
    {
      RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını boş geçemezsiniz");
      RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog İçeriğini boş geçemezsiniz");
      RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog Görseli boş geçemezsiniz");
      RuleFor(x => x.BlogTitle).MinimumLength(150).WithMessage("Lütfen 150 Karakterden daha az veri girişi yapın");
      RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("5 Karakterden daha az veri girişi yapamazsınız");
    }
  }
}
