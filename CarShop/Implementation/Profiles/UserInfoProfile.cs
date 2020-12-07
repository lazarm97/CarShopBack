using Application.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Implementation.Profiles
{
    public class UserInfoProfile : Profile
    {
        public UserInfoProfile()
        {
            CreateMap<Domain.Admin, UserInfo>();
        }
    }
}
