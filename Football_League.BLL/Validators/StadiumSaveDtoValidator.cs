using FluentValidation;
using static Football_League.BLL.Dtos.StadiumDtos;

namespace Football_League.BLL.Validators
{
    public class StadiumSaveDtoValidator : AbstractValidator<StadiumSaveDto>
    {
        public StadiumSaveDtoValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty().WithMessage("Stadion adı boş ola bilməz.")
                .MaximumLength(100).WithMessage("Stadion adı 100 simvoldan çox ola bilməz.");

            RuleFor(s => s.Capacity)
                .GreaterThan(0).WithMessage("Tutum 0-dan böyük olmalıdır.");
        }
    }
}
