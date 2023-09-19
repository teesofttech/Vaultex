﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vaultex.Persistence.Extensions
{
    internal static class IConfigurationRootExtensions
    {
        public static IConfigurationBuilder AddBasePath(this IConfigurationBuilder builder)
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var startupProjectPath = Path.Combine(currentDirectory, "../Vaultex.Web");
            var basePathConfiguration = Directory.Exists(startupProjectPath) ? startupProjectPath : currentDirectory;

            return builder.SetBasePath(basePathConfiguration);
        }
    }
}
