using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Business.Services.Logger
{
    public interface ILoggerService
    {
        void Write(string message);
    }
}
