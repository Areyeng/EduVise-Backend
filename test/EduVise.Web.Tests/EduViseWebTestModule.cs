using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using EduVise.EntityFrameworkCore;
using EduVise.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace EduVise.Web.Tests
{
    [DependsOn(
        typeof(EduViseWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class EduViseWebTestModule : AbpModule
    {
        public EduViseWebTestModule(EduViseEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(EduViseWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(EduViseWebMvcModule).Assembly);
        }
    }
}