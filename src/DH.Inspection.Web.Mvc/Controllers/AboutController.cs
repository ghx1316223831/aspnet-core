using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using DH.Inspection.Controllers;

namespace DH.Inspection.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : InspectionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
