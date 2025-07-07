using AutoMapper;
using Football_League.DAL.Entities;
using static Football_League.BLL.Dtos.Dtos;


namespace Football_League.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stadium, Dtos.Dtos.StadiumDto>().ReverseMap();
            CreateMap<Dtos.Dtos.StadiumSaveDto, Stadium>().ReverseMap();

            CreateMap<Team, Dtos.Dtos.TeamDto>().ReverseMap();
            CreateMap<Dtos.Dtos.TeamSaveDto, Team>().ReverseMap();

            CreateMap<Player, PlayerDto>().ReverseMap();
            CreateMap<PlayerSaveDto, Player>().ReverseMap();

            CreateMap<Match, MatchDto>()
                .ForMember(dest => dest.GoalScorers, opt => opt.MapFrom(src => src.MatchGoals)).ReverseMap();
            CreateMap<MatchSaveDto, Match>().ReverseMap();
            CreateMap<MatchGoal, GoalScorerDto>().ReverseMap();
            CreateMap<GoalScorerDto, MatchGoal>().ReverseMap();

            CreateMap<Player, PlayerStatsDto>();
        }
    }
}
