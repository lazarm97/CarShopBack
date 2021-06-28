using Application.DTO;
using Application.Queries.User;
using Application.Searches;
using EfDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Implementation.Queries.User
{
    public class EfGetBanUsers : IGetUserBanQuery
    {
        private readonly EfContext context;

        public EfGetBanUsers(EfContext context)
        {
            this.context = context;
        }

        public int Id => 36;

        public string Name => "Get banned users";

        public UsersBanDto Execute(UserBanSearch search)
        {
            var users = context.Users
                .Include(a => a.Address)
                .Where(x => x.IsActive == false)
                .AsQueryable();

            var usersDto = new UsersBanDto
            {
                UsersBannedDto = users.Select(x => new UserBanDto
                {
                    Id = x.Id,
                    DateTime = x.ModifiedAt.ToString(),
                    Email = x.Email,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Mobile = x.Mobile,
                    Status = "Banovan",
                }).ToList()
            };

            return usersDto;
        }
    }
}
