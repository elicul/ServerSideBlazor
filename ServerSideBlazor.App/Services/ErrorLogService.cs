using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerSideBlazor.App.Services
{
    public class ErrorLogService
    {
        private IConfigurationRoot configRoot { get; set; }

        public ErrorLogService(IConfigurationRoot configRoot)
        {
            this.configRoot = configRoot;
        }
        public string GetJsonFile()
        {
            return this.configRoot["EndpointConfigurations:Gateway"];
        }
    }
}
