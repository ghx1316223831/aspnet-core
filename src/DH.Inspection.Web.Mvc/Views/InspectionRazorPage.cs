using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace DH.Inspection.Web.Views
{
    public abstract class InspectionRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected InspectionRazorPage()
        {
            LocalizationSourceName = InspectionConsts.LocalizationSourceName;
        }
    }
}
