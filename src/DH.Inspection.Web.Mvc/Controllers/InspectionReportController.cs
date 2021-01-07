using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using DH.Inspection.Controllers;
using DH.Inspection.Authorization;

namespace DH.Inspection.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_InspectionReport)]
    public class InspectionReportController : InspectionControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult aaa()
        {
            return View();
        }
    }
}
