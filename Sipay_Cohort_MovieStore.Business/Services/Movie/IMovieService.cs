using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.DataAccess.DataAccess.Abstract;
using Sipay_Cohort_MovieStore.Dtos.Movie;
using MovieModel = Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Business.Services.Movie
{
    public interface IMovieService :IGenericService<MovieModel.Movie, MovieRequest,MovieResponse>
    {
    }
}
