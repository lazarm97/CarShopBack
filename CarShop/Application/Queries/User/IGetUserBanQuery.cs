using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.User
{
    public interface IGetUserBanQuery : IQuery<UserBanSearch,UsersBanDto>
    {
    }
}
