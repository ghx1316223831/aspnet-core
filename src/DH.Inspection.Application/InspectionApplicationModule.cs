using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DH.Inspection.Authorization;

namespace DH.Inspection
{
    [DependsOn(
        typeof(InspectionCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class InspectionApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<InspectionAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(InspectionApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
