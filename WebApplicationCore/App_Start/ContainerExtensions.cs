﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationCore
{
    public static class ContainerExtensions
    {

        public static IServiceCollection AddDIContainer(this IServiceCollection services)
        {


            return services;
        }
    }
}
