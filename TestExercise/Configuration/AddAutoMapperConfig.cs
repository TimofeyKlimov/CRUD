using AutoMapper;
using Domain.Contract;
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
            var config = new MapperConfiguration(s =>
            {
                s.CreateMap<Client, ClientDTO>().
                                    ForMember("Name", c => c.MapFrom(c => c.Name)).
                                    ForMember("TIN", c => c.MapFrom(c => c.TIN.ToString())).
                                    ForMember("CreateDate", c => c.MapFrom(c => c.CreateDate.ToShortDateString())).
                                    ForMember("Id", c => c.MapFrom(c => c.Id.ToString()));
                                    
            s.CreateMap<UpdateClientContract, Client>()
                                .ForMember("Id", c => c.MapFrom(c => Guid.Parse(c.ID)))
                                .ForMember("TIN", c => c.MapFrom(c => long.Parse(c.TIN)))
                                .ForMember("Name", c => c.MapFrom(c => c.Name))
                                .ForMember("ClientType", c => c.MapFrom(c => Enum.Parse(typeof(ClientType), c.ClientType)))
                                .ForMember("CreateDate", c => c.MapFrom(c => DateTime.Parse(c.CreateDate)));
                s.CreateMap<CreateClientContract, Client>()
                                    .ForMember("Id", c => c.MapFrom(c => Guid.NewGuid()))
                                    .ForMember("TIN", c => c.MapFrom(c => long.Parse(c.TIN)))
                                    .ForMember("Name", c => c.MapFrom(c => c.Name))
                                    .ForMember("ClientType", c => c.MapFrom(c => Enum.Parse(typeof(ClientType), c.ClientType)))
                                    .ForMember("CreateDate", c => c.MapFrom(c => DateTime.Now));
            });
            var mapper = new Mapper(config);

            services.AddSingleton<IMapper>(s => mapper);
        }
    }
}
