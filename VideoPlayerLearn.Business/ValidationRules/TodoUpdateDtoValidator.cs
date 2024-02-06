using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.ValidationRules
{
    public class TodoUpdateDtoValidator :AbstractValidator<TodoUpdateDto>
    {
        public TodoUpdateDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Bildirim Başlığı Boş Olamaz").MinimumLength(5).MaximumLength(50).WithMessage("Başlık 5-50 Karakter Olmalıdır.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bildirim Açıklaması Boş Olamaz").MinimumLength(10).WithMessage("Açıklama En Az 10 Karakter Olabilir.");
        }
    }
}
