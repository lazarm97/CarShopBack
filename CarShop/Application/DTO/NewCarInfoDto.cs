using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class NewCarInfoDto
    {
        public IEnumerable<EquipmentDto> Equipments { get; set; }
        public IEnumerable<FuelDto> Fuels { get; set; }
        public IEnumerable<CategoryDto> Categories { get; set; }
        public IEnumerable<BrandDto> Manufacturers { get; set; }
        public IEnumerable<YearOfManufacturerDto> Years { get; set; }
        public IEnumerable<DoorDto> Doors { get; set; }
        public IEnumerable<SeatDto> Seats { get; set; }
        public IEnumerable<TransmissionDto> Transmissions { get; set; }
        public IEnumerable<ColorDto> Colors { get; set; }
    }

}
