using Application.DTO;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Queries.Category
{
    public interface IGetCategoriesQuery : IQuery<CategorySearch,CategoriesDto>
    {
    }
}
