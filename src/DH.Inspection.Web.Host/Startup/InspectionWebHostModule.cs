using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DH.Inspection.Configuration;

namespace DH.Inspection.Web.Host.Startup
{
    [DependsOn(
       typeof(InspectionWebCoreModule))]
    public class InspectionWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public InspectionWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InspectionWebHostModule).GetAssembly());
        }
    }
}
