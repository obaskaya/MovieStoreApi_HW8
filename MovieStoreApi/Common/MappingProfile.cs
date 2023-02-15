using System;
using AutoMapper;
using MovieStoreApi.Application.ActorOperations.Commands.CreateActor;
using MovieStoreApi.Application.ActorOperations.Queries.GetActorDetail;
using MovieStoreApi.Application.ActorOperations.Queries.GetActors;
using MovieStoreApi.Application.CustomerOperations.CreateCustomer;
using MovieStoreApi.Application.DirectorOperations.Commands.CreateDirector;
using MovieStoreApi.Application.DirectorOperations.Queries.GetDirectorDetail;
using MovieStoreApi.Application.DirectorOperations.Queries.GetDirectors;
using MovieStoreApi.Application.MovieOperations.Commands.CreateMovie;
using MovieStoreApi.Application.MovieOperations.Queries.GetMovieDetail;
using MovieStoreApi.Application.MovieOperations.Queries.GetMovies;
using MovieStoreApi.Application.MovieOperations.UpdateMovie;
using MovieStoreApi.Application.OrderOperations.Commands.CreateOrder;
using MovieStoreApi.Application.OrderOperations.Queries.GetOrders;
using MovieStoreApi.Entities;

namespace MovieStoreApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Actor Mapping
            CreateMap<int, Actor>().ForMember(c => c.Id, c => c.MapFrom(c => c));
            CreateMap<CreateActorModel, Actor>();
            CreateMap<Actor, ActorViewModel>().ForMember(c => c.Movies, c => c.MapFrom(c => c.Movies.Select(c => c.Name).ToList()));
            CreateMap<Actor, ActorsViewModel>().ForMember(c => c.Movies, c => c.MapFrom(c => c.Movies.Select(c => c.Name).ToList()));

            //Movie Mapping
            CreateMap<int, Movie>().ForMember(c => c.Id, c => c.MapFrom(c => c));
            CreateMap<CreateMovieModel, Movie>().ForMember(c => c.Actors, c => c.MapFrom(c => c.Actors));
            CreateMap<Movie, MovieViewModel>().ForMember(c => c.Genre, c => c.MapFrom(c => c.Genre.Name)).ForMember(c => c.Director, c => c.MapFrom(c => c.Director.Name + "" + c.Director.Surname)).ForMember(c => c.Actors, c => c.MapFrom(c => c.Actors.Select(c => c.Name + " " + c.Surname).ToList()));
            CreateMap<Movie, MoviesViewModel>().ForMember(c => c.Genre, c => c.MapFrom(c => c.Genre.Name)).ForMember(c => c.Director, c => c.MapFrom(c => c.Director.Name + "" + c.Director.Surname)).ForMember(c => c.Actors, c => c.MapFrom(c => c.Actors.Select(c => c.Name + " " + c.Surname).ToList()));

            //Director Mapping
            CreateMap<CreateDirectorModel, Director>();
            CreateMap<Director, DirectorsViewModel>().ForMember(c => c.Movies, c => c.MapFrom(c => c.Movies.Select(c => c.Name).ToList()));
            CreateMap<Director, DirectorViewModel>().ForMember(c => c.Movies, c => c.MapFrom(c => c.Movies.Select(c => c.Name).ToList()));

            //Order Mapping
            CreateMap<CreateOrderModel, Order>();
            CreateMap<Order, OrderViewModel>().ForMember(c => c.CustomerName, c => c.MapFrom(c => c.Customer.Name + " " + c.Customer.Surname)).ForMember(c => c.PurchasedMovie, c => c.MapFrom(c => c.PurchasedMovie.Name));

            //Customer Mapping
            CreateMap<CreateCustomerModel, Customer>();
        }
    }
}

