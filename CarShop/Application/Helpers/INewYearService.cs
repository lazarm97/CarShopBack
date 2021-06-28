using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers
{
    public interface INewYearService
    {
        Task<bool> CheckCurrentYear();
    }
}
