using Application.Helpers;
using EfDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Helpers
{
    public class EfNewYearService : INewYearService
    {
        private readonly EfContext context;

        public EfNewYearService(EfContext context)
        {
            this.context = context;
        }

        public async Task<bool> CheckCurrentYear()
        {
            try
            {
                var lastManufacturerYear = context.YearOfManufactures.Select(x => x.Year).Max();
                if(lastManufacturerYear < DateTime.Now.Year)
                {
                    var yearDto = new Domain.YearOfManufacture
                    {
                        Year = lastManufacturerYear + 1,
                        CreatedAt = DateTime.Now,
                        IsActive = true
                    };
                    await context.YearOfManufactures.AddAsync(yearDto);
                    await context.SaveChangesAsync();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
