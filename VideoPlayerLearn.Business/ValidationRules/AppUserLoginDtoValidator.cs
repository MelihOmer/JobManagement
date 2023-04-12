using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.ValidationRules
{
    public class AppUserLoginDtoValidator :AbstractValidator<AppUserLoginDto>
    {
        public AppUserLoginDtoValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Olamaz");
        }
    }
}
