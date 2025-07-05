using Football_League.DAL.Repositories.Interfaces;
using FluentValidation;
using Football_League.DAL.Entities;
using Football_League.BLL.Dtos;

namespace Football_League.BLL.Validators
{
    public class PlayerSaveDtoValidator : AbstractValidator<Dtos.Dtos.PlayerSaveDto>
    {
        public PlayerSaveDtoValidator(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            RuleFor(p => p.FullName).NotEmpty().MaximumLength(150);
            RuleFor(p => p.JerseyNumber).InclusiveBetween(1, 99);
            RuleFor(p => p.TeamId)
                .NotEmpty()
                .MustAsync(async (id, token) => await teamRepository.AnyAsync(t => t.Id == id))
                .WithMessage("Team not found.");
           
        }
    }
}
