using AutoMapper;
using Sipay_Cohort_MovieStore.Dtos.Actor;
using Sipay_Cohort_MovieStore.Dtos.Customer;
using Sipay_Cohort_MovieStore.Dtos.Director;
using Sipay_Cohort_MovieStore.Dtos.Movie;
using Sipay_Cohort_MovieStore.Entities.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sipay_Cohort_MovieStore.Business.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie,MovieResponse>().ForMember(dest=> dest.Director,config=>config.MapFrom(src=>src.Director.Firstname+" "+src.Director.Lastname))
                .ForMember(dest=>dest.Customer,config=>config.MapFrom(src=>src.Customer.Firstname+" "+src.Customer.Lastname));
            CreateMap<MovieRequest, Movie>();

            CreateMap<Actor,ActorResponse>();
            CreateMap<ActorRequest,Actor>();

            CreateMap<Director,DirectorResponse>();
            CreateMap<DirectorRequest,Director>();

            CreateMap<CustomerRequest, Customer>();

        }
    }
}
