using Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Domain.Car, CarDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(dest => dest.ModelId, opt => opt.MapFrom(src => src.Model.Id))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Model.Brand.Name))
                .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Model.Brand.Id))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category.Id))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.NameOfColor))
                .ForMember(dest => dest.ColorId, opt => opt.MapFrom(src => src.Color.Id))
                .ForMember(dest => dest.Door, opt => opt.MapFrom(src => src.Door.NumberOfDoors))
                .ForMember(dest => dest.DoorId, opt => opt.MapFrom(src => src.Door.Id))
                .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel.NameOfFuel))
                .ForMember(dest => dest.FuelId, opt => opt.MapFrom(src => src.Fuel.Id))
                .ForMember(dest => dest.Seat, opt => opt.MapFrom(src => src.Seat.NumberOfSeats))
                .ForMember(dest => dest.SeatId, opt => opt.MapFrom(src => src.Seat.Id))
                .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission.Type))
                .ForMember(dest => dest.TransmissionId, opt => opt.MapFrom(src => src.Transmission.Id))
                .ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => src.YearOfManufacture.Year))
                .ForMember(dest => dest.YearOfManufacturerId, opt => opt.MapFrom(src => src.YearOfManufacture.Id))
                .ForMember(dest => dest.Equipments, opt => opt.MapFrom(src => src.CarEquipments.Select(x => x.Equipment.NameOfEquipment)))
                .ForMember(dest => dest.EquipmentsId, opt => opt.MapFrom(src => src.CarEquipments.Select(x => x.Equipment.Id)))
                .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Images.Select(x => x.Src)));
        }
    }
}
