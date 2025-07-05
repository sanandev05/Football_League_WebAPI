using AutoMapper;
using Football_League.DAL.Entities;
using static Football_League.BLL.Dtos.Dtos;
using static Football_League.BLL.Dtos.StadiumDtos;
using static Football_League.BLL.Dtos.TeamDtos;

namespace Football_League.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Stadium Mappings
            CreateMap<Stadium, Dtos.Dtos.StadiumDto>().ReverseMap();
            CreateMap<Dtos.Dtos.StadiumSaveDto, Stadium>().ReverseMap();

            // Team Mappings
            CreateMap<Team, Dtos.Dtos.TeamDto>().ReverseMap();
            CreateMap<Dtos.Dtos.TeamSaveDto, Team>().ReverseMap();

            // Player Mappings
            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<PlayerSaveDto, Player>().ReverseMap();

            // Match Mappings
            CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.GoalScorers, opt => opt.MapFrom(src => src.MatchGoals)).ReverseMap();
            CreateMap<MatchSaveDto, Match>().ReverseMap();
            CreateMap<MatchGoal, GoalScorerDto>().ReverseMap();
            CreateMap<GoalScorerDto, MatchGoal>().ReverseMap();

            // Report Mappings
            CreateMap<Player, PlayerStatsDto>();
        }
    }
}
