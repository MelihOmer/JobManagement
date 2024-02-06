using FluentValidation;
using VideoPlayerLearn.Entities.Dtos;

namespace VideoPlayerLearn.Business.ValidationRules
{
    public class TodoCommentCreateDtoValidator : AbstractValidator<TodoCommentCreateDto>
    {
        public TodoCommentCreateDtoValidator()
        {
            RuleFor(x => x.Definition).NotNull().NotEmpty().WithMessage("Lütfen Geçerli Bir Yorum Giriniz.");
        }
    }
}
