using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace EduVise.Controllers
{
    public abstract class EduViseControllerBase: AbpController
    {
        protected EduViseControllerBase()
        {
            LocalizationSourceName = EduViseConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
