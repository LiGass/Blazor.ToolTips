﻿using DistributedToolTips.Models;
using Microsoft.Extensions.DependencyInjection;

namespace DistributedToolTips
{
	public static class DependencyInjection
    {
        public static void AddBlazorToolTips(this IServiceCollection services)
        {
            services.AddScoped<IToolTipService, ToolTipService>();
        }

    }
}