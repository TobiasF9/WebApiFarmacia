﻿using AutoMapper;
using Services.Mappings.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Configure()
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MedicineProfile>();
            });

            IMapper mapper = mapperConfiguration.CreateMapper();
            //mapper.ConfigurationProvider.AssertConfigurationIsValid();
            return mapper;
        }
    }
}
