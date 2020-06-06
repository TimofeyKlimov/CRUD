using AutoMapper;
using Domain.DTO;
using Domain.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestExercise.Configuration
{
    public static class AddAutoMapperConfig
    {
        public static void AddMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(s => s.CreateMap<Client, ClientDTO>().
                                                    ForMember("Name", c => c.MapFrom(c => c.Name)).
                                                    ForMember("TIN",c => c.MapFrom(c => c.TIN.ToString())).
                                                    ForMember("CreateDate", c => c.MapFrom(c => c.CreateDate.ToShortDateString())).
                                                    ForMember(""));

            var mapper = new Mapper(config);

            services.AddSingleton<IMapper>(s => mapper);
        }
    }
}
