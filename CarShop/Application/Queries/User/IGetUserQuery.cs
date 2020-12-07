using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.User
{
    public interface IGetUserQuery : IQuery<int,UserInfo>
    {
    }
}
