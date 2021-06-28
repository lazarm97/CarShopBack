using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Brand
{
    public interface IGetBrandsQuery : IQuery<BrandSearch,BrandsDto>
    {
    }
}
