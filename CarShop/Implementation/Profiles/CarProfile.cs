using Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Domain.Car, CarDto>()
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model.Name))
                .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Model.Brand.Name))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
                .ForMember(dest => dest.Color, opt => opt.MapFrom(src => src.Color.NameOfColor))
                .ForMember(dest => dest.Door, opt => opt.MapFrom(src => src.Door.NumberOfDoors))
                .ForMember(dest => dest.Fuel, opt => opt.MapFrom(src => src.Fuel.NameOfFuel))
                .ForMember(dest => dest.Seat, opt => opt.MapFrom(src => src.Seat.NumberOfSeats))
                .ForMember(dest => dest.Transmission, opt => opt.MapFrom(src => src.Transmission.Type))
                .ForMember(dest => dest.YearOfManufacture, opt => opt.MapFrom(src => src.YearOfManufacture.Year));
        }
    }
}
