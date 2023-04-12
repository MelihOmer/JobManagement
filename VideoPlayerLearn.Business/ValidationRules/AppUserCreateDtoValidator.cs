using FluentValidation;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.ValidationRules
{
    public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
    {
        public AppUserCreateDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad Alanı Boş Geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad Alanı Boş Geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Alanı Boş Geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email Alanı Boş Geçilemez");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Şifre Tekrar Alanı Boş Geçilemez");

            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("Şifreler Eşleşmedi");
        }
    }
}
