using Abp.AspNetCore.Mvc.ViewComponents;

namespace DH.Inspection.Web.Views
{
    public abstract class InspectionViewComponent : AbpViewComponent
    {
        protected InspectionViewComponent()
        {
            LocalizationSourceName = InspectionConsts.LocalizationSourceName;
        }
    }
}
