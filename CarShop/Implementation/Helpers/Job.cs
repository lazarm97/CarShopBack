using Application.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Helpers
{
    public class Job
    {
        private readonly INewYearService newYearService;

        public Job(INewYearService newYearService)
        {
            this.newYearService = newYearService;
        }

        public async Task<bool> JobAsync()
        {
            var result = await newYearService.CheckCurrentYear();
            return true;
        }
    }
}
