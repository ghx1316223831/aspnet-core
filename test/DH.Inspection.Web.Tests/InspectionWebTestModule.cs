using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using DH.Inspection.EntityFrameworkCore;
using DH.Inspection.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DH.Inspection.Web.Tests
{
    [DependsOn(
        typeof(InspectionWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class InspectionWebTestModule : AbpModule
    {
        public InspectionWebTestModule(InspectionEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(InspectionWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(InspectionWebMvcModule).Assembly);
        }
    }
}