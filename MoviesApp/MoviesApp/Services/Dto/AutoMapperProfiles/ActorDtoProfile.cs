using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.Dto.AutoMapperProfiles
{
    public class ActorDtoProfile : Profile
    {
        public ActorDtoProfile()
        {
            CreateMap<Actor, ActorDto>().ReverseMap();
        }
    }
}
