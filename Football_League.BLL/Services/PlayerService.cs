using AutoMapper;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IGenericRepository<Player> _playerRepository;
        private readonly IMapper _mapper;

        public PlayerService(IGenericRepository<Player> playerRepository, IMapper mapper)
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PlayerDto>> GetAllAsync()
        {
            var players = await _playerRepository.GetAllAsync();
            return players.Select(p => _mapper.Map<PlayerDto>(p));
        }

        public async Task<PlayerDto?> GetByIdAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            return player == null ? null : _mapper.Map<PlayerDto>(player);
        }

        public async Task<PlayerDto> CreateAsync(PlayerSaveDto dto)
        {
            var player = _mapper.Map<Player>(dto);
            await _playerRepository.AddAsync(player);
            return _mapper.Map<PlayerDto>(player);
        }

        public async Task UpdateAsync(int id, PlayerSaveDto dto)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
                throw new Exception("Player not found.");

            _mapper.Map(dto, player);
            await _playerRepository.Update(player);
        }

        public async Task DeleteAsync(int id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
                throw new Exception("Player not found.");

            await _playerRepository.Delete(player);
        }
    }
}
