using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.Dtos.Director;
using DirectorModel= Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Business.Services.Director
{
    public interface IDirectorService :IGenericService<DirectorModel.Director, DirectorRequest,DirectorResponse>
    {
    }
}
