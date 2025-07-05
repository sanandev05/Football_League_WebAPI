using FluentValidation;
using Football_League.DAL.Repositories.Interfaces;
using static Football_League.BLL.Dtos.TeamDtos;

namespace Football_League.BLL.Validators
{
    public class TeamSaveDtoValidator : AbstractValidator<TeamSaveDto>
    {
        public TeamSaveDtoValidator(ITeamRepository teamRepository,IStadiumRepository stadiumRepository)
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("Komanda adı boş ola bilməz.")
                .MaximumLength(100);

            RuleFor(t => t.Code)
                .InclusiveBetween(1, 99).WithMessage("Komanda kodu 1 ilə 99 arasında olmalıdır.");

            RuleFor(t => t.StadiumId)
                .NotEmpty().WithMessage("Stadion seçilməlidir.")
                .MustAsync(async (id, cancellation) =>
                    await stadiumRepository.AnyAsync(s=>s.Id==id))
                .WithMessage("Belə bir stadion mövcud deyil.");
        }
    }
}
