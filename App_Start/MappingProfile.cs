using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleMVC.Models;
using AutoMapper;
namespace SampleMVC.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Customer, CustomerDTO>();
                cfg.CreateMap<CustomerDTO, Customer>();
            });
            //Mapper.CreateMap<Customer, CustomerDTO>();
            //Mapper.CreateMap<CustomerDTO, Customer>();

        }
    }
}