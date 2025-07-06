using AutoMapper;
using Football_League.BLL.Services.Interfaces;
using Football_League.DAL.Entities;
using Football_League.DAL.Repositories.Interfaces;
using static Football_League.BLL.Dtos.Dtos;

namespace Football_League.BLL.Services
{
    public class StadiumService : IStadiumService
    {
        private readonly IGenericRepository<Stadium> _stadiumRepository;
        private readonly IMapper _mapper;

        public StadiumService(IGenericRepository<Stadium> stadiumRepository, IMapper mapper)
        {
            _stadiumRepository = stadiumRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StadiumDto>> GetAllAsync()
        {
            var stadiums = await _stadiumRepository.GetAllAsync();
            return stadiums.Select(s => _mapper.Map<StadiumDto>(s));
        }

        public async Task<StadiumDto?> GetByIdAsync(int id)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            return stadium == null ? null : _mapper.Map<StadiumDto>(stadium);
        }

        public async Task<StadiumDto> CreateAsync(StadiumSaveDto dto)
        {
            var stadium = new Stadium
            {
                Name = dto.Name,
                Capacity = dto.Capacity
            };

            await _stadiumRepository.AddAsync(stadium);
            return _mapper.Map<StadiumDto>(stadium);
        }

        public async Task UpdateAsync(int id, StadiumSaveDto dto)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            if (stadium == null)
                throw new Exception("Stadion tapılmadı.");

            stadium.Name = dto.Name;
            stadium.Capacity = dto.Capacity;

             _stadiumRepository.Update(stadium);
        }

        public async Task DeleteAsync(int id)
        {
            var stadium = await _stadiumRepository.GetByIdAsync(id);
            if (stadium == null)
                throw new Exception("Stadion tapılmadı.");

            _stadiumRepository.Delete(stadium);
        }
    }
}
