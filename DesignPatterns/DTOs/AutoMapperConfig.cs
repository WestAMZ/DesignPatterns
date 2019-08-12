using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
using DesignPatterns.Models;

namespace DesignPatterns.DTOs
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            var cfg = new MapperConfigurationExpression();

            cfg.CreateMap<Category, CategoryDTO>()
            .ForMember(x => x.Jobs, o => o.Ignore())
            .MaxDepth(2)
            .ReverseMap();

            cfg.CreateMap<Person, PersonDTO>()
            .ForMember(x => x.Job, o=> o.MapFrom(x=>x.Job))
            .MaxDepth(2)
            .ReverseMap();

            cfg.CreateMap<Job, JobDTO>()
            .ForMember(x => x.Category, o => o.MapFrom(x => x.Category))
            .MaxDepth(2)
            .ReverseMap();

            Mapper.Initialize(cfg);
        }
    }
}
