using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.BLL.Dtos
{
    public class Dtos
    {
        public record StadiumDto(int Id, string Name, int Capacity);
        public record StadiumSaveDto(string Name, int Capacity);

        public record PlayerDto(int Id, string FullName, int JerseyNumber, int GoalsScored, int TeamId);
        public record PlayerSaveDto(string FullName, int JerseyNumber, int TeamId);

        public record TeamDto(int Id, string Name, int Code, int Wins, int Draws, int Losses, int GoalsFor, int GoalsAgainst, StadiumDto Stadium);
        public record TeamSaveDto(string Name, int Code, int StadiumId);

        public record GoalScorerDto(int PlayerId, int GoalsCount);
        public record MatchDto(int Id, int Week, int HomeTeamId, int AwayTeamId, int HomeTeamGoals, int AwayTeamGoals, IEnumerable<GoalScorerDto> GoalScorers);
        public record MatchSaveDto(int Week, int HomeTeamId, int AwayTeamId, int HomeTeamGoals, int AwayTeamGoals, IEnumerable<GoalScorerDto> GoalScorers);

        public record PlayerStatsDto(string FullName, int JerseyNumber, int GoalsScored);
        public record TeamStatsReportDto(string TeamName, int Played, int Wins, int Draws, int Losses, int GoalsFor, int GoalsAgainst, int GoalDifference, int Points, IEnumerable<PlayerStatsDto> Players);
        public record LeagueStandingDto(int Rank, string TeamName, int Played, int Wins, int Draws, int Losses, int GoalsFor, int GoalsAgainst, int GoalDifference, int Points);
        public record TopScoringPlayerDto(int Rank, string PlayerName, string TeamName, int Goals);


    }
}
