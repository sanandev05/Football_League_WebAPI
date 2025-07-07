using FluentValidation;
using Football_League.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Validators
{
    public class MatchSaveDtoValidator : AbstractValidator<MatchSaveDto>
    {
        public MatchSaveDtoValidator(ITeamRepository teamRepository, IPlayerRepository playerRepository)
        {
            RuleFor(m => m.Week).GreaterThan(0);
            RuleFor(m => m.HomeTeamId).NotEmpty();
            RuleFor(m => m.AwayTeamId).NotEmpty()
                .NotEqual(m => m.HomeTeamId).WithMessage("Home and away teams cannot be the same.");
            RuleFor(m => m.HomeTeamGoals).GreaterThanOrEqualTo(0);
            RuleFor(m => m.AwayTeamGoals).GreaterThanOrEqualTo(0);
            RuleForEach(m => m.GoalScorers).ChildRules(scorer =>
            {
                scorer.RuleFor(s => s.PlayerId).NotEmpty();
                scorer.RuleFor(s => s.GoalMinute).GreaterThan(0);
            });
        }


    }
}
