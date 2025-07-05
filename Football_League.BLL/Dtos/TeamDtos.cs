using static Football_League.BLL.Dtos.StadiumDtos;

namespace Football_League.BLL.Dtos
{
    public class TeamDtos
    {
        public record TeamDto(int Id, string Name, int Code, int Wins, int Draws, int Losses, int GoalsFor, int GoalsAgainst, StadiumDto Stadium);
        public record TeamSaveDto(string Name, int Code, int StadiumId);
    }
}
