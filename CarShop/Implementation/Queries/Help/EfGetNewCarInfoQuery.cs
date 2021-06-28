using Application.DTO;
using Application.Queries.Help;
using Application.Searches;
using EfDataAccess;
using System.Linq;

namespace Implementation.Queries.Help
{
    public class EfGetNewCarInfoQuery : IGetNewCarInfoQuery
    {
        private readonly EfContext _context;

        public EfGetNewCarInfoQuery(EfContext context)
        {
            _context = context;
        }

        public int Id => 16;

        public string Name => "Get info for new car";

        public NewCarInfoDto Execute(NewCarInfoSearch search)
        {
            var equipmentsQuery = _context.Equipments.AsQueryable();
            var fuelsQuery = _context.Fuels.AsQueryable();
            var categoriesQuery = _context.Categories.AsQueryable();
            var manufacturersQuery = _context.Brands.AsQueryable();
            var yearsQuery = _context.YearOfManufactures.OrderByDescending(x => x.Year).AsQueryable();
            var doorsQuery = _context.Doors.AsQueryable();
            var seatsQuery = _context.Seats.AsQueryable();
            var transmissionsQuery = _context.Transmissions.AsQueryable();
            var colorsQuery = _context.Colors.AsQueryable();

            var info = new NewCarInfoDto
            {
                Equipments = equipmentsQuery.Select(x => new EquipmentDto
                {
                    Id = x.Id,
                    Name = x.NameOfEquipment
                }).ToList(),
                Fuels = fuelsQuery.Select(x => new FuelDto
                {
                    Id = x.Id,
                    Name = x.NameOfFuel
                }).ToList(),
                Categories = categoriesQuery.Select(x => new CategoryDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                Manufacturers = manufacturersQuery.Select(x => new BrandDto
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList(),
                Years = yearsQuery.Select(x => new YearOfManufacturerDto
                {
                    Id = x.Id,
                    Year = x.Year
                }).ToList(),
                Colors = colorsQuery.Select(x => new ColorDto
                {
                    Id = x.Id,
                    Name = x.NameOfColor
                }).ToList(),
                Transmissions = transmissionsQuery.Select(x => new TransmissionDto
                {
                    Id = x.Id,
                    Name = x.Type
                }).ToList(),
                Doors = doorsQuery.Select(x => new DoorDto
                {
                    Id = x.Id,
                    Number = x.NumberOfDoors
                }).ToList(),
                Seats = seatsQuery.Select(x => new SeatDto
                {
                    Id = x.Id,
                    Number = x.NumberOfSeats
                }).ToList()
            };

            return info;
        }
    }
}
