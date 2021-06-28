using Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<CreateReservationDto, Domain.Reservation>()
                .ForPath(dest => dest.Car.Id, opt => opt.MapFrom(src => src.CarId))
                .ForPath(dest => dest.User.Id, opt => opt.MapFrom(src => src.UserId));
        }
    }
}
