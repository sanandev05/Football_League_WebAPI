using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football_League.BLL.Dtos
{
    public class StadiumDtos
    {
        public record StadiumDto(int Id, string Name, int Capacity);

        public record StadiumSaveDto(string Name, int Capacity);
    }
}
