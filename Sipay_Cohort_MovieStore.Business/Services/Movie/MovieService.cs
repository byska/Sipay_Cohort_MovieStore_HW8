using AutoMapper;
using FluentValidation;
using Sipay_Cohort_MovieStore.Business.Services.Generic;
using Sipay_Cohort_MovieStore.DataAccess.UnitOfWork;
using Sipay_Cohort_MovieStore.Dtos.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieModel = Sipay_Cohort_MovieStore.Entities.DbSets;

namespace Sipay_Cohort_MovieStore.Business.Services.Movie
{
    public class MovieService : GenericService<MovieModel.Movie, MovieRequest, MovieResponse>, IMovieService
    {
        public MovieService(IUow uow, IMapper mapper,IValidator<MovieRequest> validator) : base(uow, mapper, validator)
        {
        }
    }
}
