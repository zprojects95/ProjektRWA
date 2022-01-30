using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zadatak1.Models.Dto;

namespace Zadatak1.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Kupac, KupacDto>();
                
                cfg.CreateMap<Kupac, BuyerDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IDKupac))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Ime))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.Prezime));
            });

            Mapper = config.CreateMapper();
        }
    }
}