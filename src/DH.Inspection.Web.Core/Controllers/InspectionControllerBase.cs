using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace DH.Inspection.Controllers
{
    public abstract class InspectionControllerBase: AbpController
    {
        protected InspectionControllerBase()
        {
            LocalizationSourceName = InspectionConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
